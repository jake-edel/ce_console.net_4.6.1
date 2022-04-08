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


            // Tranform each flight to create list of flight variables
            string constantsTransformer = File.ReadAllText(("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/constants_transformer.json"));
            string transformedConfig = new JsonTransformer().Transform(constantsTransformer, config);
            File.WriteAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/flight_consts.json", transformedConfig);


            // Iterate through flights and transform full tower
            string towerTransformer = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/transformers/tower_transformer.json");
            string transformedTower = new JsonTransformer().Transform(towerTransformer, transformedConfig);
            File.WriteAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json", transformedTower);







            string materialsJson = File.ReadAllText("/Projects/ce_console.net_4.6.1/ce_console.net_4.6.1/data/materials.json");



            var materials = JsonConvert.DeserializeObject<Dictionary<string, Material>>(materialsJson);
            Console.WriteLine(materials["0"].Name);
            //Console.WriteLine(newList.MatList[0].Name);
            //Console.WriteLine(newList.MatList[0].LbsPerFoot);
            //Console.WriteLine(newList.MatList[1].Name);
            //Console.WriteLine(newList.MatList[2].Name);
            //Console.WriteLine(newList.MatList[3].Name);
            //Console.WriteLine(newList.MatList[4].Name);
            Console.ReadLine();

        }
    }
}