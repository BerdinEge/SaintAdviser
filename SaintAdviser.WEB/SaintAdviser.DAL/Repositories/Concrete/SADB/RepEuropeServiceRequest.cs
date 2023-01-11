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
    public class RepEuropeServiceRequest : RepGeneric<EuropeServiceRequest>, IRepEuropeServiceRequest
    {
        public RepEuropeServiceRequest(SADBBaseContext dbContext) : base(dbContext)
        {

        }
    }
}
