using System;
using JUST;
using System.IO;
using CostHelper;


namespace CostEstimator
{

    public class Program
    {
        public static float Test()
        {
            Console.WriteLine("test");
            Console.ReadLine();

            return 12.34F;
        }
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");

            string towerTransformer = File.ReadAllText(@"/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/tower_transformer.json");

            string transformedTower = new JsonTransformer().Transform(towerTransformer, input);

            string bomTransformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/flight_transformer.json"); ;

            string transformedString = new JsonTransformer().Transform(bomTransformer, input);

            //Console.WriteLine(towerTransformer);

            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/output.json", transformedString);
            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/full_tower_output.json", transformedTower);
        }
    }
}