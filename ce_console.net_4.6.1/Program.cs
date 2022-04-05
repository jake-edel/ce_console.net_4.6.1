using System;
using JUST;
using System.IO;

namespace CostEstimator
{
    public class Program
    {
        public static void Main(string[] args)
        {
            JUSTContext context = new JUSTContext
            {
                EvaluationMode = EvaluationMode.Strict,
                DefaultDecimalPlaces = 3
            };

            // Initial stair config file
            string config = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");


            // Combine initial config with material data and constants
            string materialsTransformer = File.ReadAllText(("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/materials_transformer.json"));
            string transformedConfig = new JsonTransformer(context).Transform(materialsTransformer, config);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/config+material_output.json", transformedConfig);


            // Iterate through flights and transform full tower
            string towerTransformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/tower_transformer.json");
            string transformedTower = new JsonTransformer(context).Transform(towerTransformer, transformedConfig);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json", transformedTower);

            // Transform config/material JSON into data for a single flight
            string flightTransformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/flight_transformer.json"); ;
            string transformedFlight = new JsonTransformer(context).Transform(flightTransformer, transformedConfig);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/flight_output.json", transformedFlight);
        }
    }
}