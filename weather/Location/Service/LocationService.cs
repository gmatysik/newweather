using System;
using System.Collections.Generic;
using weather.Location.Service.LocationApi;
using System.Threading.Tasks;

namespace weather.Location.Service
{
    public class LocationService : ILocationService
    {
        private readonly ILocationApi locationApi;

        public LocationService(ILocationApi _locationApi){
            this.locationApi = _locationApi;
        }

        public LocationDO LocationForCoordinates(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public async Task<List<String>> LocationsForName(string name)
        {
            List<LocationDO> locations = await this.locationApi.LocationsForName(name);
            var resultsList = new List<string>();
            //locations.ForEach(x => resultsList.Add(x.City + ", " + x.Country));
            locations.ForEach(x => resultsList.Add(x.Formatted));
            return resultsList;
        }
    }
}
