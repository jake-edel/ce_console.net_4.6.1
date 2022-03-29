using System;
using JUST;
using System.IO;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");

            string landing_transformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/landing_transformer.json"); ;

            string transformedString = new JsonTransformer().Transform(landing_transformer, input);

            Console.WriteLine(transformedString);

            File.WriteAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/output/output.json", transformedString);
        }
    }
}