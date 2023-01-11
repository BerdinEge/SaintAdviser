using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SaintAdviser.WEB.Models
{
    public class EuropeServiceViewModel
    {
        [Required]
        public string CompanyName { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        //public string WebPage { get; set; }
        public string Description { get; set; }
        
    }
}
