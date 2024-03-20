using System;
using System.Collections.Generic;
using System.Text;

namespace PrCSharp_lab_2
{
    public class GeographicCoordinates
    {
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public GeographicCoordinates(double lat, double lng)
        {
            this.Latitude = lat;
            this.Longitude = lng;
        }
    }
}
