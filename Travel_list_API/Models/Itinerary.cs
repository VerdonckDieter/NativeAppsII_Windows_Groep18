using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Travel_list_API.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public int TravelListId { get; set; }
        public double StartLatitude { get;  set;  }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }

        public Itinerary()
        {

        }

        public Itinerary(double startLatitude, double startLongitude, double endLatitude, double endLongitude)
        {
            StartLatitude = startLatitude;
            StartLongitude = startLongitude;
            EndLatitude = endLatitude;
            EndLongitude = endLongitude;
        }
    }
}
