using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class BMWCellInfoBy4110
    {
        public StringBy4110 cell_id { get; set; } = new StringBy4110();
        public StringBy4110 cell_gbt { get; set; } = new StringBy4110();
        public DateTimeBy4110 cell_supplier_measurement_time = new DateTimeBy4110();
        public DoubleBy4110 cell_supplier_voltage_v = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_capacity_ah = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_energy_wh = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_resistance_ac_w = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_resistance_dc_mw = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_short_voltage_v = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_short_current_mW = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_weight_g = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_weight_electrolyte_g = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_diameter_top_0deg_mm = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_diameter_bot_0deg_mm = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_total_height_mp29_mean_mm = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_total_height_mp29_med_mm = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_total_height_mp29_std_mm = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_batch_vent_pressure_mean_pa = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_batch_vent_pressure_med_pa = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_batch_vent_pressure_std_pa = new DoubleBy4110();
        public StringBy4110 cell_supplier_pallet_id = new StringBy4110();
        public StringBy4110 cell_supplier_box_id = new StringBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_top_120deg_mm = new DoubleOrNullBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_top_240deg_mm = new DoubleOrNullBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_mid_0deg_mm = new DoubleOrNullBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_mid_120deg_mm = new DoubleOrNullBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_mid_240deg_mm = new DoubleOrNullBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_bot_120deg_mm = new DoubleOrNullBy4110();
        public DoubleOrNullBy4110 cell_supplier_diameter_bot_240deg_mm = new DoubleOrNullBy4110();
        public DoubleBy4110 cell_supplier_total_height_mp29_mm = new DoubleBy4110();
        public DoubleBy4110 cell_supplier_batch_vent_pressure_n = new DoubleBy4110();
    }

    public class StringBy4110 : BaseCellItemInfo<string>
    {
        //public virtual string type { get; set; } = "string";
    }

    public class DoubleBy4110 : BaseCellItemInfo<double>
    {
        //public virtual string type { get; set; } = "double";
    }

    public class DoubleOrNullBy4110 : BaseCellItemInfo<double?>
    {
        //public virtual string type { get; set; } = "double";
    }

    public class DateTimeBy4110 : BaseCellItemInfo<DateTime>
    {
        //public string type { get; set; } = "date-time";
        //public string unit { get; set; } = "YYYY-MM-DD hh:mm:ss";
    }



}
