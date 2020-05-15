using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using System;

namespace weather.Filters
{
public class SampleAsyncPageFilter : IAsyncPageFilter
{
    private readonly IConfiguration _config;

    public SampleAsyncPageFilter(IConfiguration config)
    {
        _config = config;
    }

    public Task OnPageHandlerSelectionAsync(PageHandlerSelectedContext context)
    {
        object page = "";
        context.RouteData.Values.TryGetValue("page", out page);
        System.Console.WriteLine("page: " + page);        

        if(!page.Equals("/Index")){
            context.HttpContext.Session.SetString("CurrentSelection", page.ToString());
        }

        return Task.CompletedTask;
    }

    public async Task OnPageHandlerExecutionAsync(PageHandlerExecutingContext context,
                                                  PageHandlerExecutionDelegate next)
    {
        System.Console.WriteLine("OnPageHandlerExecutionAsync");

        // Do post work.
        await next.Invoke();
    }
}    
}
