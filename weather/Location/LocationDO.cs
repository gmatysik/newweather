using System;

namespace weather.Location
{
    public class LocationDO
    {
        public LocationType Type {get; set;}
        public string City { get; set; }
        public string Country { get; set; }
        public string County { get; set; }
        public string Formatted { get; set; }

        //override public string ToString() => City + ", " + Country;

        override public string ToString() => Formatted;

    }
}