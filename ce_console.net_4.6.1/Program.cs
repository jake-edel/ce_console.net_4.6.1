using System;
using JUST;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using System.Collections.Generic;

namespace CostEstimator
{
    public class Program
    {
        public static void Main(string[] args)
        {

            // Initial stair config file
            string config = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");
            TransformConfig(config);

            string materialsJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/materials.json");
            var materials = JsonConvert.DeserializeObject<Dictionary<string, Material>>(materialsJson);


            string towerJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json");            
            var flights = JsonConvert.DeserializeObject<Dictionary<string, List<Flight>>>(towerJson);

            foreach (Flight flight in flights["flights"])
            {
                Console.WriteLine(flight.FlightId);
                foreach (Part part in flight.Landing)
                {
                    if (part.MaterialId == 4)
                    {
                        Console.WriteLine(part.locDesc);
                        Console.WriteLine("Quantity Units: " + part.QtyUnits);
                        Console.WriteLine("Quantity: " + part.Quantity);
                    }
                }
            }

            Console.ReadLine();

        }

        public static void TransformConfig(string configJson)
        {
            // Tranform each flight to create list of flight variables
            string constantsTransformer = File.ReadAllText(("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/constants_transformer.json"));
            string transformedConstants = new JsonTransformer().Transform(constantsTransformer, configJson);
            File.WriteAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/flight_consts.json", transformedConstants);


            // Iterate through flights and transform full tower
            string towerTransformer = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/tower_transformer.json");
            string transformedTower = new JsonTransformer().Transform(towerTransformer, transformedConstants);
            File.WriteAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json", transformedTower);
        }
    }
}