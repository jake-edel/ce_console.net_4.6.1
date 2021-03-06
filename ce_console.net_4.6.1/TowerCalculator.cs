using System;
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

            SetFlightPrices();

            PrintFlightPrices();

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

        public void PrintFlightPrices()
        {
            double totalPrice = 0;

            foreach (Flight flight in Flights["flights"])
            {
                totalPrice += TallyFlight(flight);
            }


            Console.WriteLine("Total Cost of Stair Tower: " + totalPrice);

        }

        public double TallyFlight(Flight flight)
        {
            double totalPrice = 0;

            foreach (Part part in flight.Stairs)
            {
                totalPrice += part.Price;
            }

            foreach (Part part in flight.Landing)
            {
                totalPrice += part.Price;
            }

            foreach (Part part in flight.Railing)
            {
                totalPrice += part.Price;
            }

            Console.WriteLine("Total Price of Flight #" + flight.FlightId + ": " + totalPrice + "\n");
            return totalPrice;
        }
    }
}
