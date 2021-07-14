// ONLY NEEDED IF I RE-ADD THE VISUAL DHTMLX CALENDAR
// REMOVED DHTMLX.Scheduler.NET FROM PACKAGES ON 2021-07-12
// http://scheduler-net.com/docs/appointment-calendar-asp-mvc5.html
// using DHTMLX.Scheduler;
using Jespers_slutprojekt.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Jespers_slutprojekt.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult ChangeLanguage(string culture)
        {
            Response.Cookies.Append(CookieRequestCultureProvider.DefaultCookieName,
                CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture)),
                new CookieOptions() { Expires = DateTimeOffset.UtcNow.AddYears(1) });

            return Redirect(Request.Headers["Referer"].ToString());
        }

        public IActionResult Index()
        {
            /* ADDED 2021-07-07 BEGIN
            DHXScheduler scheduler = new DHXScheduler();            
            scheduler.Skin = DHXScheduler.Skins.Flat;
            return View(scheduler);
            
            ADDED 2021-07-07 END */
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        /*
        public IActionResult Access_Consciousness()
        {
            return View();
        }
        */

        public IActionResult Access()
        {
            return View();
        }

        public IActionResult Quotes()
        {
            return View();
        }

        public IActionResult Treatments()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
