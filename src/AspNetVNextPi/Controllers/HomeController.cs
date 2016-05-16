using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNet.Mvc;
using AspNetVNextPi.SignalRHubs;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Infrastructure;

namespace AspNetVNextPi.Controllers
{
    public class HomeController : Controller
    {
        private IHubContext LedHubContext;
        public HomeController(IConnectionManager connectionManager)
        {
            LedHubContext = connectionManager.GetHubContext<LedHub>();
        }

        public IActionResult Index()
        {

            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }

    }
}
