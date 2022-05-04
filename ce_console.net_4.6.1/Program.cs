using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CostEstimator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string configFilePath = "/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json";
            string config = File.ReadAllText(configFilePath);
            Transformation.TransformConfig(config);

            string materialsJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/materials.json");
            var materials = JsonConvert.DeserializeObject<Dictionary<string, Material>>(materialsJson);

            string towerJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json");
            var flights = JsonConvert.DeserializeObject<Dictionary<string, List<Flight>>>(towerJson);

            TowerCalculator tc = new TowerCalculator(flights, materials);

            tc.SetFlightPrices();

            tc.PrintFlightPrices();

            var towerString = JsonConvert.SerializeObject(flights);
            File.WriteAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/tower_price_output.json", towerString);

            Console.ReadLine();
        }
    }
}