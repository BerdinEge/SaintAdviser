using Microsoft.AspNetCore.Mvc;
using SaintAdviser.DAL.Repositories.Abstract.SADB;
using SaintAdviser.Entity.Entities;
using SaintAdviser.WEB.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.WEB.Controllers
{
    public class EuropeServiceController : Controller
    {
        private readonly IRepEuropeServiceRequest _repEuropeServiceRequest;
        private readonly IRepLog _repLog;
        public EuropeServiceController(IRepEuropeServiceRequest repEuropeServiceRequest, IRepLog repLog)
        {
            _repEuropeServiceRequest = repEuropeServiceRequest;
            _repLog = repLog;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(EuropeServiceViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //todo errors
                return View("Index", model);
            }

            EuropeServiceRequest newEuropeServiceRequest = new EuropeServiceRequest();
            newEuropeServiceRequest.CompanyName = model.CompanyName;
            newEuropeServiceRequest.Email = model.Email;
            newEuropeServiceRequest.Phone = model.Phone;
            string cities = "Frankfurt : " + model.FrankfurtRB.ToString() + ", Madrid : " + model.MadridRB.ToString() + ", Paris : " + model.ParisRB.ToString() + ", Milano : " + model.MilanoRB.ToString();
            newEuropeServiceRequest.CityState = cities;

            EuropeServiceRequest res = _repEuropeServiceRequest.Insert(newEuropeServiceRequest);

            Log log = new Log();
            if (res == null)
            {
                log.Message = "EuropeServiceRequest Insert Failed!";
                log.Path = "EuropeServiceController.Register";
                log.Type = enLogType.Error;
                _repLog.Insert(log);
            }
            else
            {
                log.Message = "New EuropeServiceRequest Inserted!";
                log.Path = "EuropeServiceController.Register";
                log.Type = enLogType.Trace;
                _repLog.Insert(log);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
