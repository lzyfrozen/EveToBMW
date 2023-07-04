using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class BMWTokenResult
    {
        public string access_token { get; set; }
        public string token_type { get; set; }
        public long expires_in { get; set; }
        public string scope { get; set; }
    }

    public class BMWResult
    {

        public bool valid { get; set; }
        public List<RowError> errors { get; set; }
        public string[] warnings { get; set; }
        public string[] info { get; set; }
    }

    public class RowError
    {
        public string row { get; set; }
        public string field { get; set; }
        public string message { get; set; }
    }
}
