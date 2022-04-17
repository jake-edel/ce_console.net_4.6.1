using System.Collections.Generic;

namespace CostEstimator
{
    public class TowerCalculator
    {
        public Dictionary<string, Material> Materials { get; set; }
        public Dictionary<string, List<Flight>> Flights { get; set; }

        public TowerCalculator(Dictionary<string, List<Flight>> flights, Dictionary<string, Material> materials)
        {
            Materials = materials;
            Flights = flights;

        }

        public void SetFlightPrices()
        {
            foreach (Flight flight in Flights["flights"])
            {
                foreach (Part part in flight.Stairs)
                {
                    part.SetPrice(Materials);
                }

                foreach (Part part in flight.Landing)
                {
                    part.SetPrice(Materials);
                }

                foreach (Part part in flight.Railing)
                {
                    part.SetPrice(Materials);

                }
            }
        }
    }
}
