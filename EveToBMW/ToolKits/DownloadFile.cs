using System;

namespace EveToBMW

{
    public class DownloadFile
    {
        public string FileName { get; set; }

        public string FileType { get; set; }

        public string FileToken { get; set; }

        public DownloadFile()
        {

        }

        public DownloadFile(string fileName, string fileType)
        {
            FileName = fileName;
            FileType = fileType;
            FileToken = Guid.NewGuid().ToString("N");
        }
    }
}