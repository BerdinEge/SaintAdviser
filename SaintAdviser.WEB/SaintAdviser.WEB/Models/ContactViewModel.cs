using SaintAdviser.WEB.Models.DomesticServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.WEB.Models
{
    public class ContactViewModel
    {
        public ContactViewModel()
        {
            this.ResearchPageData = new ResearchViewModel();
            this.SellOnlinePageData = new SellOnlineViewModel();
            this.DistributorshipPageData = new DistributorshipViewModel();
            this.OperationsPageData = new OperationsViewModel();
        }
        public enContactType ContactType { get; set; } = enContactType.Contact;
        [Required]
        public string FullName { get; set; } = "asdasdas";
        [Required]
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        public string WebPage { get; set; }
        public int CountryCode { get; set; }
        public int CityCode { get; set; }
        public enDomesticServiceType? DomesticServiceType { get; set; }
        public string Description { get; set; }
        public string AdditionalInformation { get; set; }
        [Required]
        public bool Policy { get; set; }

        //public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);

        public ResearchViewModel ResearchPageData { get; set; }
        public SellOnlineViewModel SellOnlinePageData { get; set; }
        public DistributorshipViewModel DistributorshipPageData { get; set; }
        public OperationsViewModel OperationsPageData { get; set; }
    }
}
