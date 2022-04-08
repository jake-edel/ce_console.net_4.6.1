
using System.Collections.Generic;


namespace CostEstimator
{
    public class Flight
    {
        public int FlightId { get; set; }
        public List<Part> Landing { get; set; } = new List<Part>();
        public List<Part> Stairs { get; set; } = new List<Part>();
        public List<Part> Railing { get; set; } = new List<Part>();
    }
}
