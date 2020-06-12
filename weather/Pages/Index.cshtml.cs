using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using weather.Location.Service;
using System.Text;
using weather.Location;
using weather.Common;

namespace weather.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILocationService _locationService;
        private List<string> locationList = new List<string>();

        public IndexModel(ILogger<IndexModel> logger, ILocationService locationService)
        {
            this._logger = logger;
            this._locationService = locationService;
        }

        public void OnGet()
        {
            HttpContext.Session.SetString("CurrentSelection", "");
        }

        public IActionResult OnGetLocationCoordinate()
        {
            System.Console.WriteLine("OnGetLocationCoordinate");
            System.Threading.Thread.Sleep(1000);
            System.Console.WriteLine("weakup");
            HttpContext.Session.SetString("CurrentLocation", "TesT");
            ViewData["CurrentLocation"] = HttpContext.Session.GetString("CurrentLocation");
            return Content("TesT");
        }

        public async Task<JsonResult> OnGetLocationNameAsync(string searchWord)
        {
            System.Console.WriteLine("OnGetLocationName");
            
            List<LocationDO> locationsList = await _locationService.LocationsForName(searchWord);
            
            System.Threading.Thread.Sleep(3000);
            HttpContext.Session.SetObjectAsJson("locations", locationsList);
            //HttpContext.Session.Set("locationsList", Encoding.UTF8.GetBytes(locationsList)) ;
            return new JsonResult(locationsList);
        }

        public IActionResult OnPostSelectLocation(String selectedLocation){
            System.Console.WriteLine("OnPostSelectLocation");
            
            var location = HttpContext.Session.GetString("CurrentSelection");            
            List<LocationDO> locations = HttpContext.Session.GetObjectAsJson<List<LocationDO>>("locations");

            //HttpContext.Session.SetString("CurrentLocation", selectedLocation);
            HttpContext.Session.SetString("CurrentLocation", locations[Int32.Parse(selectedLocation)].Formatted);
            

            if(location != null && !location.Equals("")){
                return new RedirectToPageResult(location.ToString());
                //return new RedirectToPageResult(locations[Int32.Parse(selectedLocation)].Formatted);
            } 
            return new PageResult();
        }


        
    }
}
