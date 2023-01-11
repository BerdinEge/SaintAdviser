using SaintAdviser.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.Entity.Entities
{
    public class EuropeServiceRequest : BaseEntity
    {
        public string CityState { get; set; }
        public string Phone { get; set; }
        public string CompanyName { get; set; }
        public string Email { get; set; }
    }
}
