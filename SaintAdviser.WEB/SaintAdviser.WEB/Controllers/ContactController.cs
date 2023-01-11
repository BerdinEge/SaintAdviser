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
    public class ContactController : Controller
    {
        private readonly IRepContact _repContact;
        private readonly IRepLog _repLog;
        public ContactController(IRepContact repContact, IRepLog repLog)
        {
            _repContact = repContact;
            _repLog = repLog;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register(ContactViewModel model)
        {
            if (!ModelState.IsValid)
            {
                //todo errors
            }

            Contact newContact = new Contact();
            newContact.FullName = model.FullName;
            newContact.Email = model.Email;
            newContact.Phone = model.Phone;

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
