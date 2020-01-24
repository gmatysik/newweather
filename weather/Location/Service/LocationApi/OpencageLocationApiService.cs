using System;
using System.Collections.Generic;
using weather.Data.Json;
using OpenCage.Geocode;
using System.Net.Http;
using System.Net.Http.Headers ;
using System.Text.Json;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace weather.Location.Service.LocationApi
{
    public class OpenCageLocationApiService : ILocationWebService
    {

        private static readonly HttpClient client = new HttpClient();
        Geocoder gc; 
        public OpenCageLocationApiService() : base (){
            gc = new Geocoder("");

            client.DefaultRequestHeaders.Accept.Clear();
    client.DefaultRequestHeaders.Accept.Add(
        new MediaTypeWithQualityHeaderValue("application/vnd.github.v3+json"));
    client.DefaultRequestHeaders.Add("User-Agent", ".NET Foundation Repository Reporter");
        }

        public  LocationJSON LocationForCoordinates(string latitude, string longitude)
        {
            throw new NotImplementedException();
        }

        public async Task<LocationJSON> LocationsForName(string name)
        {
            var stringTask = client.GetStringAsync("https://api.opencagedata.com/geocode/v1/json?key=335b613e80d348a18c20223487ec2a47&q=" + name);
            return await this.Location(name);
            //var repositories = await JsonSerializer.DeserializeAsync<List<Repository>>(await stringTask);
            //return repositories;

            /*GeocoderResponse result = gc.Geocode(name);
            result.Results;*/
        }

        private async Task<LocationJSON> Location(string name)
        {
            var stringTask = await client.GetStringAsync("https://api.opencagedata.com/geocode/v1/json?key=335b613e80d348a18c20223487ec2a47&q=" + name);
            //var content = await stringTask.Content.ReadAsStringAsync();

            var repositories = JsonConvert.DeserializeObject<LocationJSON>(stringTask);
            return repositories;
        } 
    }
}
