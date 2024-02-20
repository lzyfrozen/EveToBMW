namespace EveToBMW
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //load Serilog
            LogHelper.SerilogSetting();

            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            ApplicationConfiguration.Initialize();
            //Application.Run(new Demo());
            //Application.Run(new ExcelToJson());
            Application.Run(new ExcelToJsonBy4110());
            //Application.Run(new Form1());
        }
    }
}