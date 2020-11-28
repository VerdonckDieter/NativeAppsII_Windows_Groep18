using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    public class Itinerary
    {
        public String StartLocation { get;  set;  }
        public String Destination { get; set; }
        public List<String> StopOvers { get;  set;  }
        public String Transport { get;  set; }

        public Itinerary()
        {

        }

        public Itinerary(String StartLocation, String Destination, String Transport)
        {
            this.StartLocation = StartLocation;
            this.Destination = Destination;
            this.Transport = Transport;
        }

    }
}
