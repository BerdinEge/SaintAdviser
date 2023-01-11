using SaintAdviser.DAL.Repositories.Abstract.SADB;
using SaintAdviser.Data.SaintAdviserDB;
using SaintAdviser.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.DAL.Repositories.Concrete.SADB
{
    public class RepLog : RepGeneric<Log>, IRepLog
    {
        public RepLog(SADBBaseContext dbContext) : base(dbContext)
        {

        }
    }
}
