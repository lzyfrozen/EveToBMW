using Microsoft.Data.Sqlite;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class SqliteHelper
    {
        //private static string dbName1 = Path.Combine(Directory.GetCurrentDirectory(), "DB", "EveToBMW.db");//Environment.CurrentDirectory
        private static string dbName = AppSettings.app("SqliteDbPath");//Environment.CurrentDirectory
        public static string connStr = new SqliteConnectionStringBuilder()
        {
            DataSource = dbName,
            Mode = SqliteOpenMode.ReadWriteCreate
            //,Password = "admin"
        }.ToString();

        //
        public static SqlSugarClient SqlSugarDb = new SqlSugarClient(new ConnectionConfig()
        {
            ConnectionString = connStr,
            DbType = SqlSugar.DbType.Sqlite,
            IsAutoCloseConnection = true
        }, db =>
        {
            //5.1.3.24统一了语法和SqlSugarScope一样，老版本AOP可以写外面

            db.Aop.OnLogExecuting = (sql, pars) =>
            {
                Console.WriteLine(sql);//输出sql,查看执行sql 性能无影响


                //获取原生SQL推荐 5.1.4.63  性能OK
                //UtilMethods.GetNativeSql(sql,pars)

                //获取无参数化SQL 对性能有影响，特别大的SQL参数多的，调试使用
                //UtilMethods.GetSqlString(DbType.SqlServer,sql,pars)


            };

            //注意多租户 有几个设置几个
            //db.GetConnection(i).Aop

        });




    }
}
