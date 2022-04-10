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

            SumPartsByMaterial(flights, materials);

            SumFlightsBom(flights, materials);





            Console.ReadLine();
        }

        public static void SumFlightsBom(Dictionary<string, List<Flight>> flights, Dictionary<string, Material> materials)
        {
            foreach(Flight flight in flights["flights"])
            {
                //var totalWeight =
             
            }
        }

        public static void SumPartsByMaterial(Dictionary<string, List<Flight>> flights, Dictionary<string, Material> materials)
        {
            foreach (Material material in materials.Values)
            {
                double totalCount = 0;
                double totalWeight = 0;
                foreach (Flight flight in flights["flights"])
                {
                    foreach (Part part in flight.Landing)
                    {
                        if (part.MaterialId == material.Id)
                        {
                            totalCount += (part.QtyUnits * part.Quantity);
                            totalWeight += part.Weight(materials);
                        }
                    }

                    foreach (Part part in flight.Stairs)
                    {
                        if (part.MaterialId == material.Id)
                        {
                            totalCount += (part.QtyUnits * part.Quantity);
                            totalWeight += part.Weight(materials);

                        }
                    }
                    foreach (Part part in flight.Railing)
                    {
                        if (part.MaterialId == material.Id)
                        {
                            totalCount += (part.QtyUnits * part.Quantity);
                            totalWeight += part.Weight(materials);

                        }
                    }
                }

                Console.WriteLine(material.Name);
                Console.WriteLine("{0} {1}", totalCount, material.UnitOfMeasurement);
                Console.WriteLine("{0} lbs", totalWeight);
                Console.WriteLine();
            }
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