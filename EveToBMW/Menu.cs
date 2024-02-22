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
    public partial class Menu : Form
    {
        public Menu()
        {
            InitializeComponent();
        }

        private void Menu_Load(object sender, EventArgs e)
        {

        }

        private void bMW11JToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void bMW4050ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelToJson excelToJson = GenericSingleton<ExcelToJson>.CreateInstrance();
            excelToJson.Show();
        }

        private void bMW4110ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelToJsonBy4110 excelToJsonBy4110 = GenericSingleton<ExcelToJsonBy4110>.CreateInstrance();
            excelToJsonBy4110.Show();
        }

        public class GenericSingleton<T> where T : Form, new()
        {
            private static T? t = null;
            public static T CreateInstrance()
            {
                if (t == null || t.IsDisposed)
                {
                    t = new T();
                }
                else
                {
                    t.Activate();
                    t.WindowState = FormWindowState.Normal;
                }
                return t;
            }
        }
    }
}
