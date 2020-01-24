using System;
using System.Collections.Generic;
using System.IO;
using weather.Data.Json;
using System.Linq; 
using System.Threading.Tasks;

namespace weather.Location.Service.LocationApi
{
    public class OpenCageLocationApiServiceMock : ILocationWebService
    {
        private LocationJsonToDOConverter converter = new LocationJsonToDOConverter();

        public OpenCageLocationApiServiceMock() 
        {
        }

        public LocationJSON LocationForCoordinates(string latitude, string longitude)
        {            
            var filepath = "Data/coordinates_DE.json";

            if(latitude.Equals("49.50") && longitude.Equals("11.00")){
                filepath = "Data/coordinates_DE.json";
            } else {
                filepath = "Data/coordinates_PL.json";
            }

            return Newtonsoft.Json.JsonConvert.DeserializeObject<LocationJSON>(File.ReadAllText(filepath));
        }

        public async Task<LocationJSON> LocationsForName(string name)
        {
            var filepath = "Data/name_DE.json";

            if(name.Equals("pl")){
                filepath = "Data/coordinates_PL.json";
            }

            LocationJSON result = null;
            return await Task.Run(() => result = Newtonsoft.Json.JsonConvert.DeserializeObject<LocationJSON>(File.ReadAllText(filepath)));
            //return result;
        }
    }
}