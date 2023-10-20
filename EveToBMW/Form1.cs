using EveToBMW.Entity;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EveToBMW
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "DB\\excel2json-2.json");

            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");//1234
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");


            string jsonContent = File.ReadAllText(dataPath);
            List<BBACell>? list = JsonConvert.DeserializeObject<List<BBACell>>(jsonContent);


            int pageSize = 5000;
            var listCount = list.Count % pageSize == 0 ? list.Count / pageSize : list.Count / pageSize + 1;

            for (int i = 1; i <= listCount; i++)
            {
                var pageBBACell = list.Skip(pageSize * (i - 1)).Take(pageSize);

                var di = new DirectoryInfo(savePath);
                if (!di.Exists)
                {
                    di.Create();
                }

                File.WriteAllText(Path.Combine(savePath, $"ocvdata_{35 + i}.json"), pageBBACell.ToJson(true));

                Console.WriteLine(i);
            }

        }
    }
}
