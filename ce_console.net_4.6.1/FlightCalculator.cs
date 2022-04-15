using System;
using System.Collections.Generic;
using System.Linq;

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

        public Flight SelectFlight(int flightId)
        {

            var selection = from flight in Flights["flights"]
                              where flight.FlightId == flightId
                              select flight;

            return selection.First();
        }

        public void SumFlight(Flight flight)
        {
            double totalPrice = 0;

            var stairBom = from stairs in flight.Stairs
                           select stairs;

            foreach (Part part in stairBom)
            {
                Console.WriteLine(part.ToString(Materials));
                totalPrice += part.Price(Materials);
            }
            var landingBom = from landing in flight.Landing
                           select landing;

            foreach (Part part in landingBom)
            {
                Console.WriteLine(part.ToString(Materials));
                totalPrice += part.Price(Materials);

            }
            var railBom = from railing in flight.Railing
                           select railing;

            foreach (Part part in railBom)
            {
                Console.WriteLine(part.ToString(Materials));
                totalPrice += part.Price(Materials);
            }


        }
    }
}
