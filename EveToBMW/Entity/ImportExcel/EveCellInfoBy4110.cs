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

        [ExcelName("cell_supplier_resistance_ac_w")]
        public double cell_supplier_resistance_ac_w { get; set; }

        [ExcelName("cell_supplier_resistance_dc_mw")]
        public double cell_supplier_resistance_dc_mw { get; set; }


        [ExcelName("cell_supplier_resistance_dc_temperature_celsius")]
        public double cell_supplier_resistance_dc_temperature_celsius { get; set; } //2025.4.22新增

        [ExcelName("cell_supplier_resistance_uncompensated_dc_mw")]
        public double cell_supplier_resistance_uncompensated_dc_mw { get; set; }    //2025.4.22新增


        [ExcelName("cell_supplier_short_voltage_v")]
        public double cell_supplier_short_voltage_v { get; set; }

        [ExcelName("cell_supplier_short_current_mW")]
        public double cell_supplier_short_current_mW { get; set; }

        [ExcelName("cell_supplier_weight_g")]
        public double cell_supplier_weight_g { get; set; }

        [ExcelName("cell_supplier_weight_electrolyte_g")]
        public double cell_supplier_weight_electrolyte_g { get; set; }

        [ExcelName("cell_supplier_diameter_top_0deg_mm")]
        public double cell_supplier_diameter_top_0deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_bot_0deg_mm")]
        public double cell_supplier_diameter_bot_0deg_mm { get; set; }


        //[ExcelName("cell_supplier_total_height_mp29_mean_mm")]
        //public double cell_supplier_total_height_mp29_mean_mm { get; set; }   //2025.4.22删除

        //[ExcelName("cell_supplier_total_height_mp29_med_mm")]
        //public double cell_supplier_total_height_mp29_med_mm { get; set; }    //2025.4.22删除

        //[ExcelName("cell_supplier_total_height_mp29_std_mm")]
        //public double cell_supplier_total_height_mp29_std_mm { get; set; }    //2025.4.22删除

        [ExcelName("cell_supplier_batch_terminal_height_mean_mm")]
        public double cell_supplier_batch_terminal_height_mean_mm { get; set; } //2025.4.22新增
        [ExcelName("cell_supplier_batch_terminal_height_med_mm")]
        public double cell_supplier_batch_terminal_height_med_mm { get; set; }  //2025.4.22新增
        [ExcelName("cell_supplier_batch_terminal_height_std_mm")]
        public double cell_supplier_batch_terminal_height_std_mm { get; set; }  //2025.4.22新增


        [ExcelName("cell_supplier_batch_vent_pressure_mean_pa")]
        public double cell_supplier_batch_vent_pressure_mean_pa { get; set; }

        [ExcelName("cell_supplier_batch_vent_pressure_med_pa")]
        public double cell_supplier_batch_vent_pressure_med_pa { get; set; }

        [ExcelName("cell_supplier_batch_vent_pressure_std_pa")]
        public double cell_supplier_batch_vent_pressure_std_pa { get; set; }

        [ExcelName("cell_supplier_pallet_id")]
        public string cell_supplier_pallet_id { get; set; }

        [ExcelName("cell_supplier_box_id")]
        public string cell_supplier_box_id { get; set; }

        [ExcelName("cell_supplier_diameter_top_120deg_mm")]
        public double? cell_supplier_diameter_top_120deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_top_240deg_mm")]
        public double? cell_supplier_diameter_top_240deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_mid_0deg_mm")]
        public double? cell_supplier_diameter_mid_0deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_mid_120deg_mm")]
        public double? cell_supplier_diameter_mid_120deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_mid_240deg_mm")]
        public double? cell_supplier_diameter_mid_240deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_bot_120deg_mm")]
        public double? cell_supplier_diameter_bot_120deg_mm { get; set; }

        [ExcelName("cell_supplier_diameter_bot_240deg_mm")]
        public double? cell_supplier_diameter_bot_240deg_mm { get; set; }


        //[ExcelName("cell_supplier_total_height_mp29_n")]
        //public double cell_supplier_total_height_mp29_n { get; set; } //2025.4.22删除


        [ExcelName("cell_supplier_batch_terminal_height_n")]
        public double? cell_supplier_batch_terminal_height_n { get; set; } //2025.4.22新增


        [ExcelName("cell_supplier_batch_vent_pressure_n")]
        public double? cell_supplier_batch_vent_pressure_n { get; set; }

        public string edi_send_flag { get; set; } = "N";

        public DateTime? edi_send_time { get; set; }




    }
}
