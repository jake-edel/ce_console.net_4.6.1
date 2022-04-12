using JUST;
using System.IO;


namespace CostEstimator
{
    public class Transformation
    {
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
