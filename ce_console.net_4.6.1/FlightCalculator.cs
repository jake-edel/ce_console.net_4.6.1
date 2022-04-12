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

        public void SumFlight(int flightId)
        {

            var flightParts = from flight in Flights["flights"]
                              where flight.FlightId == flightId
                              select flight.Landing;


            foreach (var flight in flightParts)
            {
                var landingParts = from landing in flight
            }
        }
        public void SumAllFlights()
        {
            Dictionary<string, double> partBom = new Dictionary<string, double>();

            foreach(Flight flight in Flights["flights"])
            {
                foreach (Part part in flight.Landing)
                {
                    if (partBom.ContainsKey(part.locDesc))
                    {
                        //partBom[part.locDesc] += part.TotalUnits();
                        partBom[part.locDesc] += part.Price(Materials);

                    }
                    else
                    {
                        partBom.Add(part.locDesc, part.Price(Materials));
                        //partBom.Add(part.locDesc, part.TotalUnits());
                    }
                }
                foreach(Part part in flight.Stairs)
                {
                    if (partBom.ContainsKey(part.locDesc))
                    {
                        //partBom[part.locDesc] += part.TotalUnits();
                        partBom[part.locDesc] += part.Price(Materials);

                    }
                    else
                    {
                        partBom.Add(part.locDesc, part.Price(Materials));
                        //partBom.Add(part.locDesc, part.TotalUnits());
                    }
                }
                foreach(Part part in flight.Railing)
                {
                    if (partBom.ContainsKey(part.locDesc))
                    {
                        //partBom[part.locDesc] += part.TotalUnits();
                        partBom[part.locDesc] += part.Price(Materials);

                    }
                    else
                    {
                        partBom.Add(part.locDesc, part.Price(Materials));
                        //partBom.Add(part.locDesc, part.TotalUnits());
                    }
                }
            }
            foreach (KeyValuePair<string, double> partLengths in partBom)
            {
                Console.WriteLine(partLengths.Key + " " + partLengths.Value);
                Console.WriteLine();
            }
        }
    }
}
