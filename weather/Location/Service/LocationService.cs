using System;
using System.Collections.Generic;
using weather.Location.Service.LocationApi;
using System.Threading.Tasks;
using weather.Data.Json;

namespace weather.Location.Service
{
    public class LocationService : ILocationService
    {

        private ILocationWebService _locationWebService;

        public LocationService(ILocationWebService _locationWebService){
            this._locationWebService = _locationWebService;
        }

        public LocationDO LocationForCoordinates(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public async Task<List<String>> LocationsForName(string name)
        {
            //List<LocationDO> locations = await this.locationApi.LocationsForName(name);
            List<LocationDO> locations = await this.LocationsFor(name);
            var resultsList = new List<string>();
            //locations.ForEach(x => resultsList.Add(x.City + ", " + x.Country));
            locations.ForEach(x => resultsList.Add(x.Formatted));
            return resultsList;
        }

        public async Task<List<LocationDO>> LocationsFor(string name)
        {
            var locations = new List<LocationDO>();
            var locationJSON = await _locationWebService.LocationsForName(name);

            new List<Result>(locationJSON.results).ForEach(location =>{
              var locationDO = new LocationDO();  
                locationDO.City  = location.components.city;
                locationDO.Country  = location.components.country;
                locationDO.County  = location.components.county;
                locationDO.Formatted = location.formatted;
                Enum.TryParse(location.components._type, true, out LocationType locationType) ;
                locationDO.Type  = locationType;
                if(LocationType.City == locationType || LocationType.Village == locationType){
                    locations.Add(locationDO);
                }
            } );
            return locations;
        }
        
    }
}
