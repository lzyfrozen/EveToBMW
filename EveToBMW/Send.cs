﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EveToBMW
{
    internal class Send
    {
/*
        public void GetToken()
        {
            //RestClient
            var client = new RestClient("https://auth.osp.bmw.cloud/oauth2/token");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "Basic NnNmY3AxdThmMHU3dDk1ZDg3a21iZGZtdDY6MXRkN3UxcmtiaDByMDIydDgxb2NwdWFxNnUwcHQwamtnOTdxbTdvZmxyZGFmaGZzYzBjbQ==");
            request.AddHeader("Content-Type", "application/x-www-form-urlencoded");
            request.AddHeader("Cookie", "XSRF-TOKEN=589d05cd-9b90-40b4-874e-1297b77abf5f");
            request.AddParameter("grant_type", "client_credentials");
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            //HttpClient
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://auth.osp.bmw.cloud/oauth2/token");
            request.Headers.Add("Authorization", "Basic NnNmY3AxdThmMHU3dDk1ZDg3a21iZGZtdDY6MXRkN3UxcmtiaDByMDIydDgxb2NwdWFxNnUwcHQwamtnOTdxbTdvZmxyZGFmaGZzYzBjbQ==");
            request.Headers.Add("Cookie", "XSRF-TOKEN=1b30acd5-7ba8-47fa-ab50-4fd7f7358937");
            var collection = new List<KeyValuePair<string, string>>();
            collection.Add(new("grant_type", "client_credentials"));
            var content = new FormUrlEncodedContent(collection);
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());

        }

        public void SendOne()
        {
            //RestClient
            var client = new RestClient("https://api.osp.bmw.cloud/use-case/bat-clm-e-dev-use-case");
            client.Timeout = -1;
            var request = new RestRequest(Method.POST);
            request.AddHeader("Authorization", "eyJraWQiOiJzSXNVR2tFUVwvbzJ3XC9YT0hRTXg1QzFQN2UwOWZXb0c0S05XZmJ4NnV1dUU9IiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiI2c2ZjcDF1OGYwdTd0OTVkODdrbWJkZm10NiIsInRva2VuX3VzZSI6ImFjY2VzcyIsInNjb3BlIjoiYXBpLm9zcC5ibXcuY2xvdWRcL3VzZS1jYXNlIiwiYXV0aF90aW1lIjoxNjg3NjkwMDg4LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuZXUtd2VzdC0xLmFtYXpvbmF3cy5jb21cL2V1LXdlc3QtMV9STWdpc0VxTVkiLCJleHAiOjE2ODc2OTM2ODgsImlhdCI6MTY4NzY5MDA4OCwidmVyc2lvbiI6MiwianRpIjoiZjM2YTg3ZjctNWRiYi00OGJhLTk1MTctYzQxZGM3YzA3OGY4IiwiY2xpZW50X2lkIjoiNnNmY3AxdThmMHU3dDk1ZDg3a21iZGZtdDYifQ.EeOMVviquZYn9LjsYsYw6s8Q_z5PFOOfCT1hueUKadruxzC5zCH99zobqb2RzQUjCTTReyGZYH7XiuIbyLb3B-sJJ5Z7jPmy8qnOFrZF-al8KWCxaM9NlmEZ6hqk1xnKw_5lsNCHZtJYSpFrAUcjt6IByVgTQ4MAecdAFTVP9tjBFxrOrKuGAd-34rbMBNww0HEm99swWZXSS0KbmiCBFo2TPfY6lY8xoAN2XyhOpc_GUks2Uack-84L5otD4io8wCqslppmdVxYRiiSgk1twon5GDs-0B__Ax5MkY8qn-vnCEY6AaUIubsK6XcpYoQA3jmzZicO03ef_sjWb2uusA");
            request.AddHeader("Content-Type", "application/json");
            request.AddParameter("application/json", "{\r\n    \"cell_supplier_pallet_id\": {\r\n        \"values\": [\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\"\r\n        ]\r\n    },\r\n    \"cell_supplier_box_id\": {\r\n        \"values\": [\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\"\r\n        ]\r\n    },\r\n    \"cell_id\": {\r\n        \"values\": [\r\n            \"884493203231478102304030475601236441\",\r\n            \"884493203231478102304030473201236441\",\r\n            \"884493203231478102304030483401236431\",\r\n            \"884493203231478102304030449401236431\",\r\n            \"884493203231478102304030405701236441\"\r\n        ]\r\n    },\r\n    \"cell_gbt\": {\r\n        \"values\": [\r\n            \"04QCE83H24200JD430001665\",\r\n            \"04QCE83H24200JD430001583\",\r\n            \"04QCE83H24200JD430001736\",\r\n            \"04QCE83H24200JD430001452\",\r\n            \"04QCE83H24200JD430001032\"\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_1_pa\": {\r\n        \"values\": [\r\n            783000,\r\n            783000,\r\n            783000,\r\n            783000,\r\n            783000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_2_pa\": {\r\n        \"values\": [\r\n            794000,\r\n            794000,\r\n            794000,\r\n            794000,\r\n            794000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_3_pa\": {\r\n        \"values\": [\r\n            824000,\r\n            824000,\r\n            824000,\r\n            824000,\r\n            824000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_4_pa\": {\r\n        \"values\": [\r\n            799000,\r\n            799000,\r\n            799000,\r\n            799000,\r\n            799000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_5_pa\": {\r\n        \"values\": [\r\n            822000,\r\n            822000,\r\n            822000,\r\n            822000,\r\n            822000\r\n        ]\r\n    },\r\n    \"cell_supplier_measurement_time\": {\r\n        \"values\": [\r\n            \"2023-05-14 17:34:47\",\r\n            \"2023-05-14 17:58:53\",\r\n            \"2023-05-14 18:00:29\",\r\n            \"2023-05-14 17:57:00\",\r\n            \"2023-05-14 14:35:02\"\r\n        ]\r\n    },\r\n    \"cell_supplier_capacity_ah\": {\r\n        \"values\": [\r\n            117.858,\r\n            118.08193,\r\n            118.15794,\r\n            118.20236,\r\n            118.23242\r\n        ]\r\n    },\r\n    \"cell_supplier_energy_wh\": {\r\n        \"values\": [\r\n            441.74468,\r\n            442.00396,\r\n            442.188,\r\n            442.52948,\r\n            442.15164\r\n        ]\r\n    },\r\n    \"cell_supplier_voltage_v\": {\r\n        \"values\": [\r\n            3.6441,\r\n            3.6441,\r\n            3.6437,\r\n            3.6439,\r\n            3.644\r\n        ]\r\n    },\r\n    \"cell_supplier_short_voltage_v\": {\r\n        \"values\": [\r\n            350,\r\n            350,\r\n            350,\r\n            350,\r\n            350\r\n        ]\r\n    },\r\n    \"cell_supplier_resistance_ac_mw\": {\r\n        \"values\": [\r\n            0.0005916,\r\n            0.0006042,\r\n            0.0005967,\r\n            0.0005896,\r\n            0.0005874\r\n        ]\r\n    },\r\n    \"cell_supplier_resistance_rpt_w\": {\r\n        \"values\": [\r\n            148000,\r\n            109000,\r\n            103000,\r\n            178000,\r\n            148000\r\n        ]\r\n    },\r\n    \"cell_supplier_weight_electrolyte_g\": {\r\n        \"values\": [\r\n            264.06,\r\n            263.6,\r\n            263.41,\r\n            263.84,\r\n            263.96\r\n        ]\r\n    },\r\n    \"cell_supplier_short_current_mA\": {\r\n        \"values\": [\r\n            0.0251617541337168,\r\n            0.0278440731901352,\r\n            0.0233333333333333,\r\n            0.0358974358974359,\r\n            0.035140562248996\r\n        ]\r\n    },\r\n    \"cell_supplier_weight_g\": {\r\n        \"values\": [\r\n            1754.28,\r\n            1751.74,\r\n            1755.05,\r\n            1752.49,\r\n            1753.79\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp1_mm\": {\r\n        \"values\": [\r\n            26.48,\r\n            26.44,\r\n            26.45,\r\n            26.47,\r\n            26.47\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp2_mm\": {\r\n        \"values\": [\r\n            26.69,\r\n            26.64,\r\n            26.65,\r\n            26.66,\r\n            26.62\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp3_mm\": {\r\n        \"values\": [\r\n            26.72,\r\n            26.7,\r\n            26.72,\r\n            26.67,\r\n            26.68\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp4_mm\": {\r\n        \"values\": [\r\n            26.69,\r\n            26.65,\r\n            26.68,\r\n            26.63,\r\n            26.62\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp5_mm\": {\r\n        \"values\": [\r\n            26.48,\r\n            26.49,\r\n            26.54,\r\n            26.46,\r\n            26.49\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp6_mm\": {\r\n        \"values\": [\r\n            26.59,\r\n            26.62,\r\n            26.57,\r\n            26.6,\r\n            26.55\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp7_mm\": {\r\n        \"values\": [\r\n            26.96,\r\n            26.88,\r\n            26.81,\r\n            26.83,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp8_mm\": {\r\n        \"values\": [\r\n            27.08,\r\n            26.98,\r\n            26.92,\r\n            26.87,\r\n            26.85\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp9_mm\": {\r\n        \"values\": [\r\n            26.98,\r\n            26.88,\r\n            26.84,\r\n            26.7,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp10_mm\": {\r\n        \"values\": [\r\n            26.61,\r\n            26.55,\r\n            26.58,\r\n            26.58,\r\n            26.56\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp11_mm\": {\r\n        \"values\": [\r\n            26.58,\r\n            26.62,\r\n            26.61,\r\n            26.59,\r\n            26.53\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp12_mm\": {\r\n        \"values\": [\r\n            26.95,\r\n            26.83,\r\n            26.75,\r\n            26.81,\r\n            26.74\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp13_mm\": {\r\n        \"values\": [\r\n            27.04,\r\n            26.92,\r\n            26.86,\r\n            26.83,\r\n            26.81\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp14_mm\": {\r\n        \"values\": [\r\n            26.97,\r\n            26.83,\r\n            26.8,\r\n            26.68,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp15_mm\": {\r\n        \"values\": [\r\n            26.61,\r\n            26.58,\r\n            26.54,\r\n            26.57,\r\n            26.61\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp16_mm\": {\r\n        \"values\": [\r\n            26.5,\r\n            26.6,\r\n            26.58,\r\n            26.54,\r\n            26.43\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp17_mm\": {\r\n        \"values\": [\r\n            26.91,\r\n            26.8,\r\n            26.71,\r\n            26.7,\r\n            26.72\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp18_mm\": {\r\n        \"values\": [\r\n            26.94,\r\n            26.83,\r\n            26.79,\r\n            26.69,\r\n            26.76\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp19_mm\": {\r\n        \"values\": [\r\n            26.85,\r\n            26.76,\r\n            26.77,\r\n            26.61,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp20_mm\": {\r\n        \"values\": [\r\n            26.57,\r\n            26.49,\r\n            26.53,\r\n            26.48,\r\n            26.54\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp21_mm\": {\r\n        \"values\": [\r\n            26.55,\r\n            26.56,\r\n            26.55,\r\n            26.56,\r\n            26.55\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp22_mm\": {\r\n        \"values\": [\r\n            26.62,\r\n            26.6,\r\n            26.59,\r\n            26.58,\r\n            26.58\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp23_mm\": {\r\n        \"values\": [\r\n            26.66,\r\n            26.64,\r\n            26.65,\r\n            26.62,\r\n            26.64\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp24_mm\": {\r\n        \"values\": [\r\n            26.6,\r\n            26.59,\r\n            26.61,\r\n            26.58,\r\n            26.58\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp25_mm\": {\r\n        \"values\": [\r\n            26.53,\r\n            26.53,\r\n            26.55,\r\n            26.52,\r\n            26.54\r\n        ]\r\n    },\r\n    \"cell_supplier_length_mp26_mm\": {\r\n        \"values\": [\r\n            301.44,\r\n            301.56,\r\n            301.43,\r\n            301.46,\r\n            301.47\r\n        ]\r\n    },\r\n    \"cell_supplier_length_mp27_mm\": {\r\n        \"values\": [\r\n            301.52,\r\n            301.54,\r\n            301.54,\r\n            301.56,\r\n            301.56\r\n        ]\r\n    },\r\n    \"cell_supplier_length_mp28_mm\": {\r\n        \"values\": [\r\n            301.65,\r\n            301.67,\r\n            301.68,\r\n            301.66,\r\n            301.66\r\n        ]\r\n    },\r\n    \"cell_supplier_total_height_mp29_mm\": {\r\n        \"values\": [\r\n            94.67,\r\n            94.72,\r\n            94.67,\r\n            94.7,\r\n            94.64\r\n        ]\r\n    },\r\n    \"cell_supplier_body_height_mp30_mm\": {\r\n        \"values\": [\r\n            90.94,\r\n            90.95,\r\n            90.96,\r\n            90.93,\r\n            90.94\r\n        ]\r\n    }\r\n}", ParameterType.RequestBody);
            IRestResponse response = client.Execute(request);
            Console.WriteLine(response.Content);

            //RestClient New
            var options = new RestClientOptions("")
            {
                MaxTimeout = -1,
            };
            var client = new RestClient(options);
            var request = new RestRequest("https://api.osp.bmw.cloud/use-case/bat-clm-e-dev-use-case", Method.Post);
            request.AddHeader("Authorization", "eyJraWQiOiJzSXNVR2tFUVwvbzJ3XC9YT0hRTXg1QzFQN2UwOWZXb0c0S05XZmJ4NnV1dUU9IiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiI2c2ZjcDF1OGYwdTd0OTVkODdrbWJkZm10NiIsInRva2VuX3VzZSI6ImFjY2VzcyIsInNjb3BlIjoiYXBpLm9zcC5ibXcuY2xvdWRcL3VzZS1jYXNlIiwiYXV0aF90aW1lIjoxNjg3NzA1MDY2LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuZXUtd2VzdC0xLmFtYXpvbmF3cy5jb21cL2V1LXdlc3QtMV9STWdpc0VxTVkiLCJleHAiOjE2ODc3MDg2NjYsImlhdCI6MTY4NzcwNTA2NiwidmVyc2lvbiI6MiwianRpIjoiY2NhMzQ2MDEtNmFmOC00ZGViLWJmNjItZmY4YmY3YTgwMDZmIiwiY2xpZW50X2lkIjoiNnNmY3AxdThmMHU3dDk1ZDg3a21iZGZtdDYifQ.Ny_qlkLGiRnaKel6ItOTZK8XkyN1_fZUua_eh0ebvQMr4fbrsTTY6m-704KKkx8cWfAD9KbFtjzD6bCciLQqRO6F2It7xgUFk8szkiuMIUQosl3ydgOHmDG3OmoAH4gwrBfuTnba-EUHEmvwiJZ73-Xs5f7Ob2Zamykbp-0gDs037AZLW9rWb1lPLbrvJ3Tks1lImc-446OLeQGTa-i6k7cvXrpeROFx2RDYnmyDj1mI7XoQ_8RrnTDJBiigw0VsHut3MeW40dJndvCicGCFjc3kKr94cn8JHMX9Sw4gt-D4p5VPKAGr0JsFmm3KuXp48v4JEsQ2D0iEDF5dzMZzUQ");
            request.AddHeader("Content-Type", "application/json");
            var body = @"";
            request.AddStringBody(body, DataFormat.Json);
            RestResponse response = await client.ExecuteAsync(request);
            Console.WriteLine(response.Content);

            //HttpClient
            var client = new HttpClient();
            var request = new HttpRequestMessage(HttpMethod.Post, "https://api.osp.bmw.cloud/use-case/bat-clm-e-dev-use-case");
            request.Headers.Add("Authorization", "eyJraWQiOiJzSXNVR2tFUVwvbzJ3XC9YT0hRTXg1QzFQN2UwOWZXb0c0S05XZmJ4NnV1dUU9IiwiYWxnIjoiUlMyNTYifQ.eyJzdWIiOiI2c2ZjcDF1OGYwdTd0OTVkODdrbWJkZm10NiIsInRva2VuX3VzZSI6ImFjY2VzcyIsInNjb3BlIjoiYXBpLm9zcC5ibXcuY2xvdWRcL3VzZS1jYXNlIiwiYXV0aF90aW1lIjoxNjg3NzA1MDY2LCJpc3MiOiJodHRwczpcL1wvY29nbml0by1pZHAuZXUtd2VzdC0xLmFtYXpvbmF3cy5jb21cL2V1LXdlc3QtMV9STWdpc0VxTVkiLCJleHAiOjE2ODc3MDg2NjYsImlhdCI6MTY4NzcwNTA2NiwidmVyc2lvbiI6MiwianRpIjoiY2NhMzQ2MDEtNmFmOC00ZGViLWJmNjItZmY4YmY3YTgwMDZmIiwiY2xpZW50X2lkIjoiNnNmY3AxdThmMHU3dDk1ZDg3a21iZGZtdDYifQ.Ny_qlkLGiRnaKel6ItOTZK8XkyN1_fZUua_eh0ebvQMr4fbrsTTY6m-704KKkx8cWfAD9KbFtjzD6bCciLQqRO6F2It7xgUFk8szkiuMIUQosl3ydgOHmDG3OmoAH4gwrBfuTnba-EUHEmvwiJZ73-Xs5f7Ob2Zamykbp-0gDs037AZLW9rWb1lPLbrvJ3Tks1lImc-446OLeQGTa-i6k7cvXrpeROFx2RDYnmyDj1mI7XoQ_8RrnTDJBiigw0VsHut3MeW40dJndvCicGCFjc3kKr94cn8JHMX9Sw4gt-D4p5VPKAGr0JsFmm3KuXp48v4JEsQ2D0iEDF5dzMZzUQ");
            var content = new StringContent("{\r\n    \"cell_supplier_pallet_id\": {\r\n        \"values\": [\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\"\r\n        ]\r\n    },\r\n    \"cell_supplier_box_id\": {\r\n        \"values\": [\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\",\r\n            \"2305150027\"\r\n        ]\r\n    },\r\n    \"cell_id\": {\r\n        \"values\": [\r\n            \"884493203231478102304030475601236441\",\r\n            \"884493203231478102304030473201236441\",\r\n            \"884493203231478102304030483401236431\",\r\n            \"884493203231478102304030449401236431\",\r\n            \"884493203231478102304030405701236441\"\r\n        ]\r\n    },\r\n    \"cell_gbt\": {\r\n        \"values\": [\r\n            \"04QCE83H24200JD430001665\",\r\n            \"04QCE83H24200JD430001583\",\r\n            \"04QCE83H24200JD430001736\",\r\n            \"04QCE83H24200JD430001452\",\r\n            \"04QCE83H24200JD430001032\"\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_1_pa\": {\r\n        \"values\": [\r\n            783000,\r\n            783000,\r\n            783000,\r\n            783000,\r\n            783000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_2_pa\": {\r\n        \"values\": [\r\n            794000,\r\n            794000,\r\n            794000,\r\n            794000,\r\n            794000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_3_pa\": {\r\n        \"values\": [\r\n            824000,\r\n            824000,\r\n            824000,\r\n            824000,\r\n            824000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_4_pa\": {\r\n        \"values\": [\r\n            799000,\r\n            799000,\r\n            799000,\r\n            799000,\r\n            799000\r\n        ]\r\n    },\r\n    \"cell_supplier_batch_vent_pressure_5_pa\": {\r\n        \"values\": [\r\n            822000,\r\n            822000,\r\n            822000,\r\n            822000,\r\n            822000\r\n        ]\r\n    },\r\n    \"cell_supplier_measurement_time\": {\r\n        \"values\": [\r\n            \"2023-05-14 17:34:47\",\r\n            \"2023-05-14 17:58:53\",\r\n            \"2023-05-14 18:00:29\",\r\n            \"2023-05-14 17:57:00\",\r\n            \"2023-05-14 14:35:02\"\r\n        ]\r\n    },\r\n    \"cell_supplier_capacity_ah\": {\r\n        \"values\": [\r\n            117.858,\r\n            118.08193,\r\n            118.15794,\r\n            118.20236,\r\n            118.23242\r\n        ]\r\n    },\r\n    \"cell_supplier_energy_wh\": {\r\n        \"values\": [\r\n            441.74468,\r\n            442.00396,\r\n            442.188,\r\n            442.52948,\r\n            442.15164\r\n        ]\r\n    },\r\n    \"cell_supplier_voltage_v\": {\r\n        \"values\": [\r\n            3.6441,\r\n            3.6441,\r\n            3.6437,\r\n            3.6439,\r\n            3.644\r\n        ]\r\n    },\r\n    \"cell_supplier_short_voltage_v\": {\r\n        \"values\": [\r\n            350,\r\n            350,\r\n            350,\r\n            350,\r\n            350\r\n        ]\r\n    },\r\n    \"cell_supplier_resistance_ac_mw\": {\r\n        \"values\": [\r\n            0.0005916,\r\n            0.0006042,\r\n            0.0005967,\r\n            0.0005896,\r\n            0.0005874\r\n        ]\r\n    },\r\n    \"cell_supplier_resistance_rpt_w\": {\r\n        \"values\": [\r\n            148000,\r\n            109000,\r\n            103000,\r\n            178000,\r\n            148000\r\n        ]\r\n    },\r\n    \"cell_supplier_weight_electrolyte_g\": {\r\n        \"values\": [\r\n            264.06,\r\n            263.6,\r\n            263.41,\r\n            263.84,\r\n            263.96\r\n        ]\r\n    },\r\n    \"cell_supplier_short_current_mA\": {\r\n        \"values\": [\r\n            0.0251617541337168,\r\n            0.0278440731901352,\r\n            0.0233333333333333,\r\n            0.0358974358974359,\r\n            0.035140562248996\r\n        ]\r\n    },\r\n    \"cell_supplier_weight_g\": {\r\n        \"values\": [\r\n            1754.28,\r\n            1751.74,\r\n            1755.05,\r\n            1752.49,\r\n            1753.79\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp1_mm\": {\r\n        \"values\": [\r\n            26.48,\r\n            26.44,\r\n            26.45,\r\n            26.47,\r\n            26.47\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp2_mm\": {\r\n        \"values\": [\r\n            26.69,\r\n            26.64,\r\n            26.65,\r\n            26.66,\r\n            26.62\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp3_mm\": {\r\n        \"values\": [\r\n            26.72,\r\n            26.7,\r\n            26.72,\r\n            26.67,\r\n            26.68\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp4_mm\": {\r\n        \"values\": [\r\n            26.69,\r\n            26.65,\r\n            26.68,\r\n            26.63,\r\n            26.62\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp5_mm\": {\r\n        \"values\": [\r\n            26.48,\r\n            26.49,\r\n            26.54,\r\n            26.46,\r\n            26.49\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp6_mm\": {\r\n        \"values\": [\r\n            26.59,\r\n            26.62,\r\n            26.57,\r\n            26.6,\r\n            26.55\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp7_mm\": {\r\n        \"values\": [\r\n            26.96,\r\n            26.88,\r\n            26.81,\r\n            26.83,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp8_mm\": {\r\n        \"values\": [\r\n            27.08,\r\n            26.98,\r\n            26.92,\r\n            26.87,\r\n            26.85\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp9_mm\": {\r\n        \"values\": [\r\n            26.98,\r\n            26.88,\r\n            26.84,\r\n            26.7,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp10_mm\": {\r\n        \"values\": [\r\n            26.61,\r\n            26.55,\r\n            26.58,\r\n            26.58,\r\n            26.56\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp11_mm\": {\r\n        \"values\": [\r\n            26.58,\r\n            26.62,\r\n            26.61,\r\n            26.59,\r\n            26.53\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp12_mm\": {\r\n        \"values\": [\r\n            26.95,\r\n            26.83,\r\n            26.75,\r\n            26.81,\r\n            26.74\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp13_mm\": {\r\n        \"values\": [\r\n            27.04,\r\n            26.92,\r\n            26.86,\r\n            26.83,\r\n            26.81\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp14_mm\": {\r\n        \"values\": [\r\n            26.97,\r\n            26.83,\r\n            26.8,\r\n            26.68,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp15_mm\": {\r\n        \"values\": [\r\n            26.61,\r\n            26.58,\r\n            26.54,\r\n            26.57,\r\n            26.61\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp16_mm\": {\r\n        \"values\": [\r\n            26.5,\r\n            26.6,\r\n            26.58,\r\n            26.54,\r\n            26.43\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp17_mm\": {\r\n        \"values\": [\r\n            26.91,\r\n            26.8,\r\n            26.71,\r\n            26.7,\r\n            26.72\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp18_mm\": {\r\n        \"values\": [\r\n            26.94,\r\n            26.83,\r\n            26.79,\r\n            26.69,\r\n            26.76\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp19_mm\": {\r\n        \"values\": [\r\n            26.85,\r\n            26.76,\r\n            26.77,\r\n            26.61,\r\n            26.73\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp20_mm\": {\r\n        \"values\": [\r\n            26.57,\r\n            26.49,\r\n            26.53,\r\n            26.48,\r\n            26.54\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp21_mm\": {\r\n        \"values\": [\r\n            26.55,\r\n            26.56,\r\n            26.55,\r\n            26.56,\r\n            26.55\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp22_mm\": {\r\n        \"values\": [\r\n            26.62,\r\n            26.6,\r\n            26.59,\r\n            26.58,\r\n            26.58\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp23_mm\": {\r\n        \"values\": [\r\n            26.66,\r\n            26.64,\r\n            26.65,\r\n            26.62,\r\n            26.64\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp24_mm\": {\r\n        \"values\": [\r\n            26.6,\r\n            26.59,\r\n            26.61,\r\n            26.58,\r\n            26.58\r\n        ]\r\n    },\r\n    \"cell_supplier_thickness_mp25_mm\": {\r\n        \"values\": [\r\n            26.53,\r\n            26.53,\r\n            26.55,\r\n            26.52,\r\n            26.54\r\n        ]\r\n    },\r\n    \"cell_supplier_length_mp26_mm\": {\r\n        \"values\": [\r\n            301.44,\r\n            301.56,\r\n            301.43,\r\n            301.46,\r\n            301.47\r\n        ]\r\n    },\r\n    \"cell_supplier_length_mp27_mm\": {\r\n        \"values\": [\r\n            301.52,\r\n            301.54,\r\n            301.54,\r\n            301.56,\r\n            301.56\r\n        ]\r\n    },\r\n    \"cell_supplier_length_mp28_mm\": {\r\n        \"values\": [\r\n            301.65,\r\n            301.67,\r\n            301.68,\r\n            301.66,\r\n            301.66\r\n        ]\r\n    },\r\n    \"cell_supplier_total_height_mp29_mm\": {\r\n        \"values\": [\r\n            94.67,\r\n            94.72,\r\n            94.67,\r\n            94.7,\r\n            94.64\r\n        ]\r\n    },\r\n    \"cell_supplier_body_height_mp30_mm\": {\r\n        \"values\": [\r\n            90.94,\r\n            90.95,\r\n            90.96,\r\n            90.93,\r\n            90.94\r\n        ]\r\n    }\r\n}", null, "application/json");
            request.Content = content;
            var response = await client.SendAsync(request);
            response.EnsureSuccessStatusCode();
            Console.WriteLine(await response.Content.ReadAsStringAsync());


        }
*/    
    }
}
