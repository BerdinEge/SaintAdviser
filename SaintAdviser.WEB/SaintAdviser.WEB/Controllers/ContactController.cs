using Microsoft.AspNetCore.Mvc;
using SaintAdviser.DAL.Repositories.Abstract.SADB;
using SaintAdviser.Entity.Entities;
using SaintAdviser.WEB.Models;
using SaintAdviser.WEB.Models.DomesticServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.WEB.Controllers
{
    public class ContactController : Controller
    {
        private readonly IRepContact _repContact;
        private readonly IRepLog _repLog;
        public ContactController(IRepContact repContact, IRepLog repLog)
        {
            _repContact = repContact;
            _repLog = repLog;
        }

        public IActionResult Index(ContactViewModel model = null)
        {
            if (model == null)
            {
                return View();
            }
            else
            {
                return View(model);
            }
        }
        
        public IActionResult SellOnline(SellOnlineViewModel prevModel)
        {
            ContactViewModel model = new ContactViewModel();
            model.ContactType = enContactType.DomesticServiceRequest;
            model.SellOnlinePageData = prevModel;
            return View("Index", model);
        }

        public IActionResult Distributorship(DistributorshipViewModel prevModel)
        {
            ContactViewModel model = new ContactViewModel();
            model.ContactType = enContactType.DomesticServiceRequest;
            model.DistributorshipPageData = prevModel;
            return View("Index", model);
        }

        public IActionResult Operations(OperationsViewModel prevModel)
        {
            ContactViewModel model = new ContactViewModel();
            model.ContactType = enContactType.DomesticServiceRequest;
            model.OperationsPageData = prevModel;
            return View("Index", model);
        }

        public IActionResult Register(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            Contact newContact = new Contact();
            newContact.ContactType = model.ContactType;
            newContact.FullName = model.FullName;
            newContact.Email = model.Email;
            newContact.Phone = model.Phone;
            string ResearchPageData = JsonSerializer.Serialize(model.ResearchPageData);
            string SellOnlinePageData = JsonSerializer.Serialize(model.SellOnlinePageData);
            string DistributorshipPageData = JsonSerializer.Serialize(model.DistributorshipPageData);
            string OperationsPageData = JsonSerializer.Serialize(model.OperationsPageData);
            newContact.Description = "ResearchPageData: " + ResearchPageData + ", SellOnlinePageData: " + SellOnlinePageData + ", DistributorshipPageData: " + DistributorshipPageData + ", OperationsPageData:  " + OperationsPageData;
            Contact res = _repContact.Insert(newContact);

            Log log = new Log();
            if(res == null)
            {
                log.Message = "Contact Insert Failed!";
                log.Path = "ContactController.Register";
                log.Type = enLogType.Error;
                _repLog.Insert(log);
            }
            else
            {
                log.Message = "New Contact Inserted!";
                log.Path = "ContactController.Register";
                log.Type = enLogType.Trace;
                _repLog.Insert(log);
            }

            return RedirectToAction("Index", "Home");
        }
    }
}
