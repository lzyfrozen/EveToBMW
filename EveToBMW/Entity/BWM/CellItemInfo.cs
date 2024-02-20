using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class BaseCellItemInfo<T>
    {
        public virtual List<T> values { get; set; } = new List<T>();
    }

    public class CellItemInfo<T> : BaseCellItemInfo<T>
    {
        public override List<T> values { get; set; } = new List<T>();
        public virtual string type { get; set; } = "string";
        public virtual string nullable { get; set; } = "not nullable";
        public virtual string unit { get; set; } = "string";

    }
}
