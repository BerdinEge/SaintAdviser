﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SaintAdviser.WEB.Controllers
{
    public class EuropeServicesController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
