using EveToBMW;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    public class EveCellInfo
    {
        [ExcelName("cell_supplier_pallet_id")]
        public string cell_supplier_pallet_id { get; set; }
        [ExcelName("cell_supplier_box_id")]
        public string cell_supplier_box_id { get; set; }
        [ExcelName("cell_id")]
        public string cell_id { get; set; }
        [ExcelName("cell_gbt")]
        [SugarColumn(IsPrimaryKey = true)]
        public string cell_gbt { get; set; }
        [ExcelName("cell_supplier_batch_vent_pressure_1_pa")]
        public double cell_supplier_batch_vent_pressure_1_pa { get; set; }
        [ExcelName("cell_supplier_batch_vent_pressure_2_pa")]
        public double cell_supplier_batch_vent_pressure_2_pa { get; set; }
        [ExcelName("cell_supplier_batch_vent_pressure_3_pa")]
        public double cell_supplier_batch_vent_pressure_3_pa { get; set; }
        [ExcelName("cell_supplier_batch_vent_pressure_4_pa")]
        public double cell_supplier_batch_vent_pressure_4_pa { get; set; }
        [ExcelName("cell_supplier_batch_vent_pressure_5_pa")]
        public double cell_supplier_batch_vent_pressure_5_pa { get; set; }
        [ExcelName("cell_supplier_measurement_time")]
        public DateTime cell_supplier_measurement_time { get; set; }
        [ExcelName("cell_supplier_capacity_ah")]
        public double cell_supplier_capacity_ah { get; set; }
        [ExcelName("cell_supplier_energy_wh")]
        public double cell_supplier_energy_wh { get; set; }
        [ExcelName("cell_supplier_voltage_v")]
        public double cell_supplier_voltage_v { get; set; }
        [ExcelName("cell_supplier_short_voltage_v")]
        public double cell_supplier_short_voltage_v { get; set; }
        [ExcelName("cell_supplier_resistance_ac_mw")]
        public double cell_supplier_resistance_ac_mw { get; set; }
        [ExcelName("cell_supplier_resistance_rpt_w")]
        public double cell_supplier_resistance_rpt_w { get; set; }
        [ExcelName("cell_supplier_weight_electrolyte_g")]
        public double cell_supplier_weight_electrolyte_g { get; set; }
        [ExcelName("cell_supplier_short_current_mA")]
        public double cell_supplier_short_current_mA { get; set; }
        [ExcelName("cell_supplier_weight_g")]
        public double cell_supplier_weight_g { get; set; }
        [ExcelName("cell_supplier_thickness_mp1_mm")]
        public double cell_supplier_thickness_mp1_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp2_mm")]
        public double cell_supplier_thickness_mp2_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp3_mm")]
        public double cell_supplier_thickness_mp3_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp4_mm")]
        public double cell_supplier_thickness_mp4_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp5_mm")]
        public double cell_supplier_thickness_mp5_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp6_mm")]
        public double cell_supplier_thickness_mp6_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp7_mm")]
        public double cell_supplier_thickness_mp7_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp8_mm")]
        public double cell_supplier_thickness_mp8_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp9_mm")]
        public double cell_supplier_thickness_mp9_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp10_mm")]
        public double cell_supplier_thickness_mp10_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp11_mm")]
        public double cell_supplier_thickness_mp11_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp12_mm")]
        public double cell_supplier_thickness_mp12_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp13_mm")]
        public double cell_supplier_thickness_mp13_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp14_mm")]
        public double cell_supplier_thickness_mp14_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp15_mm")]
        public double cell_supplier_thickness_mp15_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp16_mm")]
        public double cell_supplier_thickness_mp16_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp17_mm")]
        public double cell_supplier_thickness_mp17_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp18_mm")]
        public double cell_supplier_thickness_mp18_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp19_mm")]
        public double cell_supplier_thickness_mp19_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp20_mm")]
        public double cell_supplier_thickness_mp20_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp21_mm")]
        public double cell_supplier_thickness_mp21_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp22_mm")]
        public double cell_supplier_thickness_mp22_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp23_mm")]
        public double cell_supplier_thickness_mp23_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp24_mm")]
        public double cell_supplier_thickness_mp24_mm { get; set; }
        [ExcelName("cell_supplier_thickness_mp25_mm")]
        public double cell_supplier_thickness_mp25_mm { get; set; }
        [ExcelName("cell_supplier_length_mp26_mm")]
        public double cell_supplier_length_mp26_mm { get; set; }
        [ExcelName("cell_supplier_length_mp27_mm")]
        public double cell_supplier_length_mp27_mm { get; set; }
        [ExcelName("cell_supplier_length_mp28_mm")]
        public double cell_supplier_length_mp28_mm { get; set; }
        [ExcelName("cell_supplier_total_height_mp29_mm")]
        public double cell_supplier_total_height_mp29_mm { get; set; }
        [ExcelName("cell_supplier_body_height_mp30_mm")]
        public double cell_supplier_body_height_mp30_mm { get; set; }

        public string edi_send_flag { get; set; } = "N";

        public DateTime? edi_send_time { get; set; }

    }
}
