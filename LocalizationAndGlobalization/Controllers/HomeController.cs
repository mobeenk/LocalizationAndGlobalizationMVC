using LocalizationAndGlobalization.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Localization;

namespace LocalizationAndGlobalization.Controllers
{
    public class HomeController : Controller
    {

        private readonly ILogger<HomeController> _logger;
        private readonly IHtmlLocalizer<HomeController> _localizer;

        public HomeController(ILogger<HomeController> logger,IHtmlLocalizer<HomeController> localizer)
        {
            _logger = logger;
            _localizer = localizer;
        }

        public IActionResult Index()
        {
            var test = _localizer["HelloWorld"];
            ViewData["Privacy"] = _localizer["Privacy"];
            ViewData["HelloWorld"] = test;
            return View();
        }
        [HttpPost]
        public IActionResult CultureManagment(string culture,string returnUrl)
        {
            Response.Cookies.Append(
                 CookieRequestCultureProvider.DefaultCookieName,
                    CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                    new CookieOptions {Expires = DateTimeOffset.Now.AddDays(30)}
                );
                ;
                return LocalRedirect(returnUrl);
        }


        public IActionResult Privacy()
        {
            ViewData["Privacy"] = _localizer["Privacy"];
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
