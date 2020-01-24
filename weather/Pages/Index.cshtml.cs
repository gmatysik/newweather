using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;
using weather.Location.Service;

namespace weather.Pages
{

    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        private readonly ILocationService _locationService;

        public IndexModel(ILogger<IndexModel> logger, ILocationService locationService)
        {
            this._logger = logger;
            this._locationService = locationService;
        }

        public void OnGet()
        {

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
            
            List<String> locationsList = await _locationService.LocationsForName(searchWord);
            
            /*var list = new List<string>();
            list.Add("About" + searchWord);
            list.Add("Test1" + searchWord);
            System.Threading.Thread.Sleep(3000);*/
            System.Threading.Thread.Sleep(3000);
            return new JsonResult(locationsList);
            //ViewData["CurrentLocation"] = HttpContext.Session.GetString("CurrentLocation");
            //return Content("TesT");
        }

        
    }
}
