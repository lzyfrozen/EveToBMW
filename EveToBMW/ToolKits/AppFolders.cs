using System;

namespace EveToBMW
{
    public class AppFolders : IAppFolders
    {
        public string TempFileDownloadFolder { get; set; }

        public string TempFileUploadFolder { get; set; }

        public string SampleProfileImagesFolder { get; set; }

        public string WebLogsFolder { get; set; }

        public string TemplateFolder { get; set; }
    }

    public interface IAppFolders
    {
        string TempFileDownloadFolder { get; set; }

        string TempFileUploadFolder { get; set; }

        string SampleProfileImagesFolder { get; set; }

        string WebLogsFolder { get; set; }

        string TemplateFolder { get; set; }
    }
}