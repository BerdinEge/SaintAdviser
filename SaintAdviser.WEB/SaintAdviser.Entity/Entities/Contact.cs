using SaintAdviser.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.Entity.Entities
{
    public class Contact : BaseEntity
    {
        public enContactType ContactType { get; set; }
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
        public string Country { get; set; }
        public string Region { get; set; }
        public string City { get; set; }
        public enDomesticServiceType? DomesticServiceType { get; set; }
        public string Description { get; set; }

    }
}
