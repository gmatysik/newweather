using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace weather.Location.Service
{
    public interface ILocationService
    {
        LocationDO LocationForCoordinates(string latitude, string longitude);

        Task<List<String>> LocationsForName(string name);

    }
}
