using System;
using System.IO;
using Newtonsoft.Json;
using System.Collections.Generic;

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

            tc.SumFlight(0);

            //tc.SumAllFlights();

            Console.ReadLine();
        }
    }
}