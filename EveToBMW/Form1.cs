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

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var str = "System.Nullable`1[[System.Double, System.Private.CoreLib, Version=6.0.0.0, Culture=neutral, PublicKeyToken=7cec85d7bea7798e]]";
            var a1 = str.IndexOf("System.Nullable");
            var a2 = str.IndexOf("[[");
            var a3 = str.IndexOf(",");
            var a4 = str.Substring(a2 + 2, a3 - a2 - 2);
            Console.WriteLine(str);
            Console.WriteLine(a1);
            Console.WriteLine(a4);


            return;


            string dataPath = Path.Combine(Directory.GetCurrentDirectory(), "DB\\excel2json-1.json");

            //var path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Upload");//
            string savePath = Path.Combine(Directory.GetCurrentDirectory(), "Upload");


            string jsonContent = File.ReadAllText(dataPath);
            List<BBACell>? list = JsonConvert.DeserializeObject<List<BBACell>>(jsonContent);


            int pageSize = 3;//5000
            var listCount = list.Count % pageSize == 0 ? list.Count / pageSize : list.Count / pageSize + 1;

            for (int i = 1; i <= listCount; i++)
            {
                var pageBBACell = list.Skip(pageSize * (i - 1)).Take(pageSize);

                var di = new DirectoryInfo(savePath);
                if (!di.Exists)
                {
                    di.Create();
                }

                File.WriteAllText(Path.Combine(savePath, $"ocvdata_{i}.json"), pageBBACell.ToJson(true));

                Console.WriteLine(i);
            }

        }

    }
}
