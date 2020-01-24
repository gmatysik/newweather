using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace weather.Location.Service.LocationApi
{
    public interface ILocationApi
    {
        public LocationDO LocationForCoordinates(string latitude, string longitude);

        public Task<List<LocationDO>> LocationsForName(string name);

    }
}
