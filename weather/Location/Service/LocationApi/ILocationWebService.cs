using System;
using weather.Data.Json;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace weather.Location.Service.LocationApi
{
    public interface ILocationWebService
    {
        public  LocationJSON LocationForCoordinates(string latitude, string longitude);

        public Task<LocationJSON> LocationsForName(string name);

    }
}
