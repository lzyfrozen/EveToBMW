using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class EveCellInfoBy4110
    {
        [ExcelName("cell_id")]
        public string cell_id { get; set; }

        [ExcelName("cell_gbt")]
        [SugarColumn(IsPrimaryKey = true)]
        public string cell_gbt { get; set; }

        [ExcelName("cell_supplier_measurement_time")]
        public DateTime cell_supplier_measurement_time { get; set; }

        [ExcelName("cell_supplier_voltage_v")]
        public double cell_supplier_voltage_v { get; set; }

        [ExcelName("cell_supplier_capacity_ah")]
        public double cell_supplier_capacity_ah { get; set; }

        [ExcelName("cell_supplier_energy_wh")]
        public double cell_supplier_energy_wh { get; set; }


    }
}
