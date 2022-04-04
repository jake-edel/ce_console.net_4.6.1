using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostMethods
{
    public class FlightSolver
    {
        public static double StringerArea(int totalRise, int totalRun, int stringerWidth, bool isDdl, float rise, float run)
        {
            double length = FindHypotenuse(totalRise, totalRun, isDdl, rise, run);
            double value = length * stringerWidth;
            return Math.Truncate(100 * value) / 100;

        }
        public static double FindHypotenuse(float totalRise, float totalRun, bool isDdl, float rise, float run)
        {
            if (isDdl)
            {
                totalRise += rise;
                totalRun += run;
            }
            double value = Math.Sqrt(Math.Pow(totalRise, 2) + Math.Pow(totalRun, 2));
            return Math.Truncate(100 * value) / 100;
        }

        public static int IntPostQuantity(int run)
        {
            float value = (float)run / 48;
            return (int)Math.Ceiling(value);
        }

        public static int PicketQuantity(int run)
        {
            int value = run / 4;

            return value;
        }
    }
}
