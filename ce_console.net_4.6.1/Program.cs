using System;
using JUST;
using System.IO;
using JUST.NET.Test;


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

            string config = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");

            string materialsTransformer = File.ReadAllText(("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/materials_transformer.json"));
            string transformedConfig = new JsonTransformer(context).Transform(materialsTransformer, config);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/config+material_output.json", transformedConfig);


            string towerTransformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/tower_transformer.json");
            string transformedTower = new JsonTransformer(context).Transform(towerTransformer, config);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json", transformedTower);


            string flightTransformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/flight_transformer.json"); ;
            string transformedFlight = new JsonTransformer(context).Transform(flightTransformer, config);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/flight_output.json", transformedFlight);
        }
    }
}