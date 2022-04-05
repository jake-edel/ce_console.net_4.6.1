using System;


namespace CostMethods
{
    public class FlightSolver
    {
        public static double StringerArea(int totalRise, int totalRun, int stringerWidth, bool isDdl, float rise, float run)
        {
            double length = FindDdlHypotenuse(totalRise, totalRun, isDdl, rise, run);
            double value = length * stringerWidth;
            return Math.Truncate(100 * value) / 100;

        }
        public static double FindDdlHypotenuse(float totalRise, float totalRun, bool isDdl, float rise, float run)
        {
            if (isDdl)
            {
                totalRise += rise;
                totalRun += run;
            }
            double value = Math.Sqrt(Math.Pow(totalRise, 2) + Math.Pow(totalRun, 2));
            return Math.Truncate(100 * value) / 100;
        }
        public static double FindHypotenuse(float rise, float run)
        {
            double value = Math.Sqrt(Math.Pow(rise, 2) + Math.Pow(run, 2));
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

        public static int SupportStudQuantity(float landingWidth)
        {
            double value = (landingWidth - 7.25) / 18;
            return (int)Math.Ceiling(value);
        }
    }
}
