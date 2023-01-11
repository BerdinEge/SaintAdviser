using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.Entity.Globals
{
    public class AppGlobals
    {
        public static string ConnectionString { get; set; }
        public static enDbProviderType dbProviderType { get; set; }

    }
}
