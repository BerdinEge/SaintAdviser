using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.Entity.Enums
{
    public class DomainEnums
    {
        public enum enDbProviderType
        {
            None,
            MSSQL,
            MySQL
        }
        public enum enDomesticServiceType
        {
            Research = 0,
            SellOnline = 1,
            Distributorship = 2,
            Operations = 3
        }
    }
    
}
