using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaintAdviser.WEB.Controllers
{
    public class TurkeyServiceController : Controller
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
    }
}
