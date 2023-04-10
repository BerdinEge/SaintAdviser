using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SaintAdviser.WEB.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace SaintAdviser.WEB.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Research()
        {
            return View();
        }

        public IActionResult SellOnline()
        {
            return View();
        }

        public IActionResult Distributorship()
        {
            return View();
        }

        public IActionResult Operations()
        {
            return View();
        }

        public IActionResult Financial()
        {
            return View();
        }
    }
}
