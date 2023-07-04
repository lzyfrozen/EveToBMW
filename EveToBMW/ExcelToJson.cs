using Microsoft.Extensions.Caching.Memory;
using OfficeOpenXml;
using OfficeOpenXml.Packaging.Ionic.Zip;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveToBMW
{
    public partial class ExcelToJson : Form
    {
        private delegate void ShowDelegate(TextBox textBox, string message, bool isClear = false);
        private ShowDelegate showDelegate;
        private Stopwatch sw = new Stopwatch();
        private List<BMWCellInfo> listBMWCellInfo = new List<BMWCellInfo>();
        private readonly IEdiRequest _ediRequest = new EdiRequest();
        private LogHelper logHelper = new LogHelper();
        private readonly IMemoryCache _memoryCache = new MemoryCache(new MemoryCacheOptions());
        //private TextBox tbContext= tbEveJson(TextBox)tabMessageBox.TabPages["tabPageOutput"].Controls["tbContext"];
        //private TextBox =tbEveJson(TextBox)tabMessageBox.TabPages["tabPageEveJson"].Controls["tbEveJson"];
        //private TextBox tbBmwJson = (TextBox)tabMessageBox.TabPages["tabPageBmwJson"].Controls["tbBmwJson"];

        public ExcelToJson()
        {
            InitializeComponent();
            showDelegate = ShowMessage;
        }

        private void ExcelToJson_Load(object sender, EventArgs e)
        {
            //logHelper.SerilogTest();
        }

        private void btnChoice_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Microsoft Excel files(*.xls)|*.xls;*.xlsx";
            //dialog.InitialDirectory = "";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                tbFile.Text = dialog.FileName;
            }
        }

        private void btnExcelToJson_Click(object sender, EventArgs e)
        {
            try
            {
                tbContext.Clear();
                tbBmwJson.Clear();
                tbEveJson.Clear();
                //var tbContext = (TextBox)tabMessageBox.TabPages["tabPageOutput"].Controls["tbContext"];
                //var tbEveJson = (TextBox)tabMessageBox.TabPages["tabPageEveJson"].Controls["tbEveJson"];
                //var tbBmwJson = (TextBox)tabMessageBox.TabPages["tabPageBmwJson"].Controls["tbBmwJson"];

                var tbpath = tbFile.Text.Trim();
                if (string.IsNullOrWhiteSpace(tbpath))
                {
                    MessageBox.Show("请先上传文件!");
                    return;
                }
                var load = LoadFile(tbpath);
                if (!load.Item1)
                {
                    MessageBox.Show(load.Item2);
                    return;
                }
                string path = load.Item2;

                List<EveCellInfo> lstExcel = new List<EveCellInfo>();

                sw.Start();
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial;
                List<ExcelWorksheet> lstworksheet = ExcelHelper.Instance.LoadExcel(path);
                sw.Stop();
                showDelegate(tbContext, $"Excel{path}加载完毕,耗时{sw.ElapsedMilliseconds}");

                sw.Restart();
                var listEveCellInfo = ExcelHelper.Instance.LoadFromExcel<EveCellInfo>(lstworksheet[0], t => { return string.IsNullOrEmpty(t.cell_gbt); });
                sw.Stop();
                showDelegate(tbContext, $"sheet表{lstworksheet[0].Name}读取完毕,耗时{sw.ElapsedMilliseconds}");

                var lsit = SqliteHelper.SqlSugarDb.Queryable<EveCellInfo>().ToList();
                //insert db
                sw.Restart();
                SqliteHelper.SqlSugarDb.Insertable(listEveCellInfo).ExecuteCommand();
                sw.Stop();
                showDelegate(tbContext, $"sheet表{lstworksheet[0].Name}插入表{listEveCellInfo.Count}条记录完成,耗时{sw.ElapsedMilliseconds}");

                //query
                sw.Restart();
                var lsitEveCellInfo = SqliteHelper.SqlSugarDb.Queryable<EveCellInfo>().Where(l => l.edi_send_flag == "N").ToList();
                sw.Stop();
                showDelegate(tbContext, $"查询未发送记录{lsitEveCellInfo.Count}条,耗时{sw.ElapsedMilliseconds}");

                sw.Restart();
                var EveCellInfoJson = lsitEveCellInfo.ToJsonDate(chkFormat.Checked);
                sw.Stop();
                showDelegate(tbEveJson, $"转换EveCell-Json成功,共{lsitEveCellInfo.Count}条,耗时{sw.ElapsedMilliseconds}{Environment.NewLine}{EveCellInfoJson}", true);

                sw.Restart();
                listBMWCellInfo = EveMapToBMW(lsitEveCellInfo);
                var index = 1;
                tbBmwJson.Clear();
                foreach (var item in listBMWCellInfo)
                {
                    var strJson = item.ToJsonDate(chkFormat.Checked);

                    showDelegate(tbBmwJson, $"第{index}页-----------------------------------------------{Environment.NewLine}{strJson}");
                    index++;
                }
                sw.Restart();
                showDelegate(tbContext, $"转换BmwCell-Json成功,耗时{sw.ElapsedMilliseconds}");

            }
            catch (Exception ex)
            {
                tbContext.Text += $"error:{ex.Message}{Environment.NewLine}";
                //throw;
            }
        }

        private void btnQueryDB_Click(object sender, EventArgs e)
        {
            tbContext.Clear();
            tbBmwJson.Clear();
            tbEveJson.Clear();
            //query
            sw.Restart();
            var lsitEveCellInfo = SqliteHelper.SqlSugarDb.Queryable<EveCellInfo>().Where(l => l.edi_send_flag == "N").ToList();
            sw.Stop();
            showDelegate(tbContext, $"查询未发送记录{lsitEveCellInfo.Count}条,耗时{sw.ElapsedMilliseconds}");

            sw.Restart();
            var EveCellInfoJson = lsitEveCellInfo.ToJsonDate(chkFormat.Checked);
            sw.Stop();
            showDelegate(tbEveJson, $"转换EveCell-Json成功,共{lsitEveCellInfo.Count}条,耗时{sw.ElapsedMilliseconds}{Environment.NewLine}{EveCellInfoJson}", true);

            sw.Restart();
            listBMWCellInfo = EveMapToBMW(lsitEveCellInfo);
            var index = 1;
            foreach (var item in listBMWCellInfo)
            {
                var strJson = item.ToJsonDate(chkFormat.Checked);

                showDelegate(tbBmwJson, $"第{index}页----------------------------------------------------------------------------------------------{Environment.NewLine}{strJson}");
                index++;
            }
            sw.Restart();
            showDelegate(tbContext, $"转换BmwCell-Json成功,耗时{sw.ElapsedMilliseconds}");
        }

        private void btnSendBMW_Click(object sender, EventArgs e)
        {
            if (listBMWCellInfo == null || listBMWCellInfo.Count == 0)
            {
                MessageBox.Show("没有数据,请导入或者查询!");
                return;
            }

            var index = 0;
            foreach (var item in listBMWCellInfo)
            {
                try
                {
                    index++;
                    showDelegate(tbContext, $"第{index}页,开始发送----------------------------------------------------------------------------------------------");
                    var bSendFlag = SendBMW(item, index);
                    if (bSendFlag)
                    {
                        showDelegate(tbContext, $"第{index}页,发送成功!!!");
                    }
                }
                catch (TokenException ex)
                {
                    showDelegate(tbContext, $"异常,第{index}页,发送失败!返回结果:{Environment.NewLine}{ex}");
                    break;
                    //throw;
                }
                catch (Exception ex)
                {
                    showDelegate(tbContext, $"异常,第{index}页,发送失败!返回结果:{Environment.NewLine}{ex}");
                    continue;
                    //throw;
                }
            }
        }

        private bool SendBMW(BMWCellInfo message, int index)
        {
            bool bSendFlag = false;
            try
            {
                var ApiUrl = AppSettings.app(new[] { "BMW", "ApiUrl" });
                FeedbackDto dto = new FeedbackDto();
                dto.PlatformNo = "BMW";
                dto.Method = ApiUrl;
                dto.FeedbackType = FeedbackTypes.BMW;
                dto.Header = GetHeader();
                dto.Data = message.ToJsonDate();


                var result = _ediRequest.Feedback<BMWResult>(dto);
                showDelegate(tbContext, $"第{index}页,已发送!返回结果:{Environment.NewLine}{result.ToJsonDate(true)}");
                if (result.valid.Equals(true) && result.errors.Count == 0)
                {
                    showDelegate(tbContext, $"第{index}页,接口发送成功!");
                    ModifyData(message);

                    showDelegate(tbContext, $"第{index}页,数据表发送标记修改成功!!");
                    bSendFlag = true;
                }
                else
                {
                    showDelegate(tbContext, $"第{index}页,接口发送失败!");
                }
            }
            catch (Exception)
            {
                throw;
            }
            return bSendFlag;
        }

        private void ModifyData(BMWCellInfo message)
        {
            var lsitEveCellInfo = SqliteHelper.SqlSugarDb.Queryable<EveCellInfo>().Where(l => l.edi_send_flag == "N").In(l => l.cell_gbt, message.cell_gbt.values).ToList();
            var dateNow = DateTime.Now;
            var lsitEveCellInfo_Edit = lsitEveCellInfo.Select(l => { l.edi_send_flag = "Y"; l.edi_send_time = dateNow; return l; }).ToList();
            //批量
            SqliteHelper.SqlSugarDb.Fastest<EveCellInfo>().BulkUpdate(lsitEveCellInfo_Edit);

            //var result = SqliteHelper.SqlSugarDb.Updateable(lsitEveCellInfo)
            //    .SetColumns(it=>it.edi_send_flag=="Y")
            //    .SetColumns(it => it.edi_send_time == DateTime.Now)
            //    .ExecuteCommand();
        }


        private Dictionary<string, string> GetHeader()
        {
            var dicHeader = new Dictionary<string, string>();
            string access_token = string.Empty;
            if (!_memoryCache.TryGetValue("token", out access_token))
            {
                _memoryCache.Set("token", GetToken(), new MemoryCacheEntryOptions()
                {
                    //SlidingExpiration = TimeSpan.FromMinutes(5),
                    AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(30)
                });
            }
            access_token = _memoryCache.Get<string>("token");
            dicHeader.Add("Authorization", $"{access_token}");

            return dicHeader;
        }

        private string GetToken()
        {
            var token = string.Empty;
            var tokenApiUrl = AppSettings.app(new[] { "BMW", "Auth", "TokenApiUrl" });
            var grantType = AppSettings.app(new[] { "BMW", "Auth", "GrantType" });
            var userName = AppSettings.app(new[] { "BMW", "Auth", "UserName" });
            var password = AppSettings.app(new[] { "BMW", "Auth", "Password" });
            var encodeStr = Base64Helper.Base64Encode($"{userName}:{password}");
            var dicHeader = new Dictionary<string, string>();
            dicHeader.Add("Authorization", $"Basic {encodeStr}");
            var dicParams = new Dictionary<string, string>();
            dicParams.Add("grant_type", grantType);

            FeedbackDto dto = new FeedbackDto();
            dto.PlatformNo = "BMW";
            dto.Method = tokenApiUrl;
            dto.FeedbackType = FeedbackTypes.BMW;
            //dto.Data = data.ToJsonDate();
            dto.Header = dicHeader;
            dto.Params = dicParams;
            try
            {
                var result = _ediRequest.Oauth<BMWTokenResult>(dto);
                token = result.access_token;
                if (string.IsNullOrWhiteSpace(token))
                {
                    showDelegate(tbContext, $"获取token失败!");
                }
                else
                {
                    showDelegate(tbContext, $"获取token成功!{Environment.NewLine}{result.ToJsonDate(true)}");
                }
            }
            catch (Exception ex)
            {
                showDelegate(tbContext, $"获取token失败!");
                throw new TokenException($"获取token失败!", ex);
                //MessageBox.Show($"token获取失败,{ex.ToString()}");
            }
            return token;
        }

        private Tuple<bool, string> LoadFile(string strFileName)
        {
            var dataStr = $"{DateTime.Now:yyyyMMddHHmmssffff}";
            FileInfo file = new FileInfo(strFileName);
            if (file == null)
            {
                return new Tuple<bool, string>(false, "文件不能为空");
            }
            if (!Path.GetExtension(file.Name).EndsWith("xlsx") && !Path.GetExtension(file.Name).EndsWith("xls"))
            {
                return new Tuple<bool, string>(false, "请上传正确的文件");
            }
            var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");
            var di = new DirectoryInfo(path);
            if (!di.Exists)
            {
                di.Create();
            }
            var fileName = dataStr + file.Name;
            path += "\\" + Path.GetFileName(fileName);

            file.CopyTo(path);
            //using (FileStream fsRead = new FileStream(file.FullName, FileMode.Open))
            //{
            //    using (FileStream fsWrite = new FileStream(path, FileMode.OpenOrCreate))
            //    {
            //            byte[] bt =new byte[(int)fsRead.Length];
            //            int r = fsRead.Read(bt, 0, bt.Length);
            //            fsWrite.Write(bt, 0, bt.Length);
            //    }
            //}

            return new Tuple<bool, string>(true, path);
        }
        
        //测试
        private void TestDome()
        {
            List<EveCellInfo> list = new List<EveCellInfo>();
            for (int i = 1; i <= 120; i++)
            {
                var end = "_" + i.ToString().PadLeft(4, '0');
                EveCellInfo cell = new EveCellInfo();
                cell.cell_supplier_pallet_id = "pallet_id" + end;
                cell.cell_supplier_box_id = "box_id" + end;
                cell.cell_id = "id" + end;
                cell.cell_gbt = "gbt" + end;
                cell.cell_supplier_batch_vent_pressure_1_pa = 78300;
                cell.cell_supplier_batch_vent_pressure_2_pa = 78300;
                cell.cell_supplier_batch_vent_pressure_3_pa = 78300;
                cell.cell_supplier_batch_vent_pressure_4_pa = 78300;
                cell.cell_supplier_batch_vent_pressure_5_pa = 78300;
                cell.cell_supplier_measurement_time = DateTime.Now.AddSeconds(i);
                cell.cell_supplier_capacity_ah = 117 + (double)i / 1000;
                cell.cell_supplier_energy_wh = 441 + (double)i / 1000;
                cell.cell_supplier_voltage_v = 3 + (double)i / 1000;
                cell.cell_supplier_short_voltage_v = 350;
                cell.cell_supplier_resistance_ac_w = (double)i / 10000;
                cell.cell_supplier_resistance_rpt_w = 148000 + i;
                cell.cell_supplier_weight_electrolyte_g = 263 + (double)i / 1000;
                cell.cell_supplier_short_current_mA = (double)i / 10000;
                cell.cell_supplier_weight_g = 1751 + (double)i / 1000;
                cell.cell_supplier_thickness_mp1_mm = 21 + (double)i / 1000;
                cell.cell_supplier_thickness_mp2_mm = 22 + (double)i / 1000;
                cell.cell_supplier_thickness_mp3_mm = 23 + (double)i / 1000;
                cell.cell_supplier_thickness_mp4_mm = 24 + (double)i / 1000;
                cell.cell_supplier_thickness_mp5_mm = 25 + (double)i / 1000;
                cell.cell_supplier_thickness_mp6_mm = 26 + (double)i / 1000;
                cell.cell_supplier_thickness_mp7_mm = 27 + (double)i / 1000;
                cell.cell_supplier_thickness_mp8_mm = 28 + (double)i / 1000;
                cell.cell_supplier_thickness_mp9_mm = 29 + (double)i / 1000;
                cell.cell_supplier_thickness_mp10_mm = 30 + (double)i / 1000;
                cell.cell_supplier_thickness_mp11_mm = 31 + (double)i / 1000;
                cell.cell_supplier_thickness_mp12_mm = 32 + (double)i / 1000;
                cell.cell_supplier_thickness_mp13_mm = 33 + (double)i / 1000;
                cell.cell_supplier_thickness_mp14_mm = 34 + (double)i / 1000;
                cell.cell_supplier_thickness_mp15_mm = 35 + (double)i / 1000;
                cell.cell_supplier_thickness_mp16_mm = 36 + (double)i / 1000;
                cell.cell_supplier_thickness_mp17_mm = 37 + (double)i / 1000;
                cell.cell_supplier_thickness_mp18_mm = 38 + (double)i / 1000;
                cell.cell_supplier_thickness_mp19_mm = 39 + (double)i / 1000;
                cell.cell_supplier_thickness_mp20_mm = 40 + (double)i / 1000;
                cell.cell_supplier_thickness_mp21_mm = 41 + (double)i / 1000;
                cell.cell_supplier_thickness_mp22_mm = 42 + (double)i / 1000;
                cell.cell_supplier_thickness_mp23_mm = 43 + (double)i / 1000;
                cell.cell_supplier_thickness_mp24_mm = 44 + (double)i / 1000;
                cell.cell_supplier_thickness_mp25_mm = 45 + (double)i / 1000;
                cell.cell_supplier_length_mp26_mm = 46 + (double)i / 1000;
                cell.cell_supplier_length_mp27_mm = 47 + (double)i / 1000;
                cell.cell_supplier_length_mp28_mm = 48 + (double)i / 1000;
                cell.cell_supplier_total_height_mp29_mm = 49 + (double)i / 1000;
                cell.cell_supplier_body_height_mp30_mm = 50 + (double)i / 1000;
                list.Add(cell);
            }

            var listSend = EveMapToBMW(list);

            foreach (var item in listSend)
            {
                var strJson = item.ToJsonDate();
            }

        }

        /// <summary>
        /// Eve信息转BMW信息,根据配置MessageSize的大小
        /// </summary>
        /// <param name="listEveCellInfo"></param>
        /// <returns></returns>
        private List<BMWCellInfo> EveMapToBMW(List<EveCellInfo> listEveCellInfo)
        {
            var messageSize = int.Parse(AppSettings.app(new[] { "BMW", "MessageSize" }));
            var listCount = listEveCellInfo.Count % messageSize == 0 ? listEveCellInfo.Count / messageSize : listEveCellInfo.Count / messageSize + 1;

            List<BMWCellInfo> list = new List<BMWCellInfo>();

            for (int i = 1; i <= listCount; i++)
            {
                var pageEveCellInfo = listEveCellInfo.Skip(messageSize * (i - 1)).Take(messageSize);

                BMWCellInfo bmwCellInfo = new BMWCellInfo();

                bmwCellInfo.cell_supplier_pallet_id.values = pageEveCellInfo.Select(l => l.cell_supplier_pallet_id).ToList();
                bmwCellInfo.cell_supplier_box_id.values = pageEveCellInfo.Select(l => l.cell_supplier_box_id ?? string.Empty).ToList();
                bmwCellInfo.cell_id.values = pageEveCellInfo.Select(l => l.cell_id).ToList();
                bmwCellInfo.cell_gbt.values = pageEveCellInfo.Select(l => l.cell_gbt).ToList();
                bmwCellInfo.cell_supplier_batch_vent_pressure_1_pa.values = pageEveCellInfo.Select(l => l.cell_supplier_batch_vent_pressure_1_pa).ToList();
                bmwCellInfo.cell_supplier_batch_vent_pressure_2_pa.values = pageEveCellInfo.Select(l => l.cell_supplier_batch_vent_pressure_2_pa).ToList();
                bmwCellInfo.cell_supplier_batch_vent_pressure_3_pa.values = pageEveCellInfo.Select(l => l.cell_supplier_batch_vent_pressure_3_pa).ToList();
                bmwCellInfo.cell_supplier_batch_vent_pressure_4_pa.values = pageEveCellInfo.Select(l => l.cell_supplier_batch_vent_pressure_4_pa).ToList();
                bmwCellInfo.cell_supplier_batch_vent_pressure_5_pa.values = pageEveCellInfo.Select(l => l.cell_supplier_batch_vent_pressure_5_pa).ToList();
                bmwCellInfo.cell_supplier_measurement_time.values = pageEveCellInfo.Select(l => l.cell_supplier_measurement_time).ToList();
                bmwCellInfo.cell_supplier_capacity_ah.values = pageEveCellInfo.Select(l => l.cell_supplier_capacity_ah).ToList();
                bmwCellInfo.cell_supplier_energy_wh.values = pageEveCellInfo.Select(l => l.cell_supplier_energy_wh).ToList();
                bmwCellInfo.cell_supplier_voltage_v.values = pageEveCellInfo.Select(l => l.cell_supplier_voltage_v).ToList();
                bmwCellInfo.cell_supplier_short_voltage_v.values = pageEveCellInfo.Select(l => l.cell_supplier_short_voltage_v).ToList();
                bmwCellInfo.cell_supplier_resistance_ac_w.values = pageEveCellInfo.Select(l => l.cell_supplier_resistance_ac_w).ToList();
                bmwCellInfo.cell_supplier_resistance_rpt_w.values = pageEveCellInfo.Select(l => l.cell_supplier_resistance_rpt_w).ToList();
                bmwCellInfo.cell_supplier_weight_electrolyte_g.values = pageEveCellInfo.Select(l => l.cell_supplier_weight_electrolyte_g).ToList();
                bmwCellInfo.cell_supplier_short_current_mA.values = pageEveCellInfo.Select(l => l.cell_supplier_short_current_mA).ToList();
                bmwCellInfo.cell_supplier_weight_g.values = pageEveCellInfo.Select(l => l.cell_supplier_weight_g).ToList();
                bmwCellInfo.cell_supplier_thickness_mp1_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp1_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp2_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp2_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp3_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp3_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp4_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp4_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp5_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp5_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp6_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp6_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp7_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp7_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp8_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp8_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp9_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp9_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp10_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp10_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp11_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp11_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp12_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp12_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp13_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp13_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp14_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp14_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp15_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp15_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp16_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp16_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp17_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp17_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp18_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp18_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp19_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp19_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp20_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp20_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp21_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp21_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp22_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp22_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp23_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp23_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp24_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp24_mm).ToList();
                bmwCellInfo.cell_supplier_thickness_mp25_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_thickness_mp25_mm).ToList();
                bmwCellInfo.cell_supplier_length_mp26_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_length_mp26_mm).ToList();
                bmwCellInfo.cell_supplier_length_mp27_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_length_mp27_mm).ToList();
                bmwCellInfo.cell_supplier_length_mp28_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_length_mp28_mm).ToList();
                bmwCellInfo.cell_supplier_total_height_mp29_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_total_height_mp29_mm).ToList();
                bmwCellInfo.cell_supplier_body_height_mp30_mm.values = pageEveCellInfo.Select(l => l.cell_supplier_body_height_mp30_mm).ToList();

                list.Add(bmwCellInfo);
            }

            return list;
        }

        private void ShowMessage(string message, bool isClear = false)
        {
            if (isClear)
            {
                tbContext.Clear();
            }
            tbContext.AppendText($"{DateTime.Now:yyyyMMddHHmmssffff},{message}{Environment.NewLine}");
            tbContext.ScrollToCaret();
        }

        private void ShowMessage(TextBox textBox, string message, bool isClear = false)
        {
            if (isClear)
            {
                textBox.Clear();
            }
            textBox.AppendText($"{DateTime.Now:yyyyMMddHHmmssffff},{message}{Environment.NewLine}");
            textBox.ScrollToCaret();
        }


        public class TokenException : Exception
        {
            public TokenException() { }
            public TokenException(string? message) : base(message) { }
            public TokenException(string? message, Exception inner) : base(message, inner) { }
            public TokenException(HttpStatusCode code, object errors = null)
            {
                Code = code;
                Errors = errors;
            }

            public HttpStatusCode Code { get; }
            public object? Errors { get; }
        }
    }
}
