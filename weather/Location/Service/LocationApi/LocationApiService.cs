using System;
using System.Collections.Generic;
using weather.Data.Json;
using System.Threading.Tasks;


namespace weather.Location.Service.LocationApi
{
    /**
    * Intermedate serice between application and concrete rest service
    */
    public class LocationApiService : ILocationApi
    {
        
        private ILocationWebService _locationWebService;

        public LocationApiService(ILocationWebService locationWebService)
        {
            _locationWebService = locationWebService;//mock or real service
        }

        public LocationDO LocationForCoordinates(string latitude, string longitude)
        {
            var locationDTO = _locationWebService.LocationForCoordinates(latitude, longitude);
            
            var result = new LocationDO();
            result.City = locationDTO.results[0].components.city;
            result.Country = locationDTO.results[0].components.country;
            //result.Country = locationDTO.results[0].components.postcode;
            result.Formatted = locationDTO.results[0].components.postcode + ", " + result.City + ", " + result.Country;

            return result;   

        }

        public async Task<List<LocationDO>> LocationsForName(string name)
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
