using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using JUST;
using System.IO;

namespace Test
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string input = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/stair_configuration.json");

            string transformer = File.ReadAllText("/Users/Jake/source/repos/ce_console.net_4.6.1/ce_console.net_4.6.1/data/landing_transformer.json"); ;


            //JUSTContext context = new JUSTContext
            //{
            //    EvaluationMode = EvaluationMode.FallbackToDefault,

            //};

            string transformedString = new JsonTransformer().Transform(transformer, input);

            Console.WriteLine(transformedString);
        }
    }
}