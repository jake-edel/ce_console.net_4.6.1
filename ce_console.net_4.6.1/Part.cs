using System.Collections.Generic;
using System.Text;

namespace CostEstimator
{
    public class Part
    {
        public string locDesc { get; set; }
        public int MaterialId { get; set; }
        public double QtyUnits { get; set; }
        public int Quantity { get; set; }

        public double TotalUnits() => QtyUnits * Quantity;

        public double LengthFt() => TotalUnits() / 12;

        public double AreaSqFt() => TotalUnits() / 144;

        public double QtyPricingUnits(Dictionary<string, Material> materials)
        {
            if (materials[MaterialId.ToString()].UnitOfMeasurement == "in")
            {
                double value = materials[MaterialId.ToString()].LbsPerFoot * LengthFt();
                return System.Math.Truncate(100 * value) / 100;
            } 
            else if (materials[MaterialId.ToString()].UnitOfMeasurement == "sqIn")
            {
                double value = materials[MaterialId.ToString()].LbsPerFoot * AreaSqFt();
                return System.Math.Truncate(100 * value) / 100;
            } 
            else if ((materials[MaterialId.ToString()].UnitOfMeasurement == "ea"))
            {
                return Quantity;
            }
            else if ((materials[MaterialId.ToString()].UnitOfMeasurement == "ft"))
            {
                return LengthFt();
            } else
            {
                return 0;
            }
        }

        public double Price(Dictionary<string, Material> materials)
        {
            double value = QtyPricingUnits(materials) * materials[MaterialId.ToString()].PricePerUnit;
            return System.Math.Truncate(100 * value) / 100;
        }

        public string ToString(Dictionary<string, Material> materials)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(locDesc);
            sb.AppendLine("QuantityUnits: " + QtyUnits);
            sb.AppendLine("Unit of Measurement: " + materials[MaterialId.ToString()].UnitOfMeasurement);
            sb.AppendLine("Quantity: " + Quantity);
            sb.AppendLine("Total Units: " + TotalUnits());
            sb.AppendLine("Price: " + Price(materials));
            return sb.ToString();
        }
    }
}
