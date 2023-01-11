using SaintAdviser.Entity.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static SaintAdviser.Entity.Enums.DomainEnums;

namespace SaintAdviser.Entity.Entities
{
    public class Log : BaseEntity
    {
        public enLogType Type { get; set; }
        public string Path { get; set; }
        public string Message { get; set; }
        public string Detail { get; set; }
        public string Request { get; set; }

    }
}
