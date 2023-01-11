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
        public string FullName { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
        public string WebPage { get; set; }
        public int CountryCode { get; set; }
        public int CityCode { get; set; }
        public enDomesticServiceType? DomesticServiceType { get; set; }
        public string Description { get; set; }

    }
}
