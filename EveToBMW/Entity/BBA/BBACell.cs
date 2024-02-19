using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW.Entity
{
    public class BBACell
    {
        /// <summary>
        /// 电池电芯国标编码 (国标码)
        /// </summary>
        public string gbtCode { get; set; }

        /// <summary>
        /// 电池宝马编码(DMC码)
        /// </summary>
        public string bmwCode { get; set; }

        /// <summary>
        /// 电池厂商规格
        /// </summary>
        public string facSpecCode { get; set; }
    }
}
