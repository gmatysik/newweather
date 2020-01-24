using System;
using System.Collections;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace weather.Pages
{

    public class BasePageModel<T> : PageModel 
    {
        public string Location = "Default";

        private readonly ILogger<T> _logger;

        public BasePageModel(ILogger<T> logger)
        {
            _logger = logger;
        }

        public IActionResult OnGetLocationCoordinate()
        {
            System.Console.WriteLine("OnGetLocationCoordinate");
            System.Threading.Thread.Sleep(5000);
            System.Console.WriteLine("weakup");
            this.Location = "TesT";
            return Content("TesT");
        }
    }
}
