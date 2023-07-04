using SqlSugar;
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
    public partial class Demo : Form
    {
        public Demo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LogHelper logHelper = new LogHelper();
            logHelper.SerilogTest();




            var lsit = SqliteHelper.SqlSugarDb.Queryable<Employee>().ToList();

            //更新
            SqliteHelper.SqlSugarDb.Updateable(new Employee() { EmployeeId = 1, LastName = "Adams", FirstName = "Andrew", Address = "中国湖北省荆门市", City = "荆门" }).ExecuteCommand();

            //插入
            //SqliteHelper.SqlSugarDb.Insertable(new Employee() { , Name = "jack" }).ExecuteCommand();

        }

        private void Demo_Load(object sender, EventArgs e)
        {

        }
    }
}
