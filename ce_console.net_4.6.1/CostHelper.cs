using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CostMethods
{
    public class StringerSolver
    {
        public static double StringerArea(int rise, int run, int stringerWidth)
        {
            double length = FindHypotenuse(rise, run);
            double value = length * stringerWidth;
            return Math.Truncate(100 * value) / 100;

        }
        public static double FindHypotenuse(int rise, int run)
        {
            double value = Math.Sqrt(Math.Pow(rise, 2) + Math.Pow(run, 2));
            return Math.Truncate(100 * value) / 100;
        }
    }
}
