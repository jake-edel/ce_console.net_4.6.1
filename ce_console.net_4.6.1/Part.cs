using System.Collections.Generic;

namespace CostEstimator
{
    public class Part
    {
        public string locDesc { get; set; }
        public int MaterialId { get; set; }
        public double QtyUnits { get; set; }
        public int Quantity { get; set; }

        public double Weight(Dictionary<string, Material> materials)
        {
            if (materials[MaterialId.ToString()].UnitOfMeasurement == "in")
            {
                double lengthFt = (QtyUnits * Quantity) / 12;
                double value = materials[MaterialId.ToString()].LbsPerFoot * lengthFt;
                return System.Math.Truncate(100 * value) / 100;
            } 
            else if (materials[MaterialId.ToString()].UnitOfMeasurement == "sqFt")
            {
                double lengthFt = (QtyUnits * Quantity) / 144;
                double value = materials[MaterialId.ToString()].LbsPerFoot * lengthFt;
                return System.Math.Truncate(100 * value) / 100;
            } 
            else if ((materials[MaterialId.ToString()].UnitOfMeasurement == "ea"))
            {
                return Quantity;
            }
            else
            {
                return 0;
            }


        }
    }
}
