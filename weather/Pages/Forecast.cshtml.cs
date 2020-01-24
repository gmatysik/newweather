using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

namespace weather.Pages
{
    public class ForecastModel : PageModel
    {
        private readonly ILogger<ForecastModel> _logger;

        public ForecastModel(ILogger<ForecastModel> logger)
        {
            this._logger = logger;
        }

        public void OnGet()
        {
            ViewData["CurrentLocation"] = HttpContext.Session.GetString("CurrentLocation");
        }
    }
}
