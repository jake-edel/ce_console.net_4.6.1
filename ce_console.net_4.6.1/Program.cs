using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace CostEstimator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string config = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");
            Transformation.TransformConfig(config);

            string materialsJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/materials.json");
            var materials = JsonConvert.DeserializeObject<Dictionary<string, Material>>(materialsJson);

            string towerJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json");
            var flights = JsonConvert.DeserializeObject<Dictionary<string, List<Flight>>>(towerJson);

            TowerCalculator tc = new TowerCalculator(flights, materials);

            var flt = tc.SelectFlight(0);

            tc.SumFlight(flt);



            Console.ReadLine();
        }
    }
}