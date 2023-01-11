using Microsoft.EntityFrameworkCore;
using SaintAdviser.Entity.Entities;
using SaintAdviser.Entity.Globals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.Data.SaintAdviserDB
{
    public class SADBMSSQLContext : SADBBaseContext
    {
        public SADBMSSQLContext(DbContextOptions dbContext) : base(dbContext) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(AppGlobals.ConnectionString);
            }

            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Contact>().Property(c => c.Phone).HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Contact>().Property(c => c.Description).HasColumnType("nvarchar(max)");

            modelBuilder.Entity<EuropeServiceRequest>().Property(c => c.CityState).HasColumnType("nvarchar(max)");

            modelBuilder.Entity<Log>().Property(c => c.Detail).HasColumnType("nvarchar(max)");
            modelBuilder.Entity<Log>().Property(c => c.Request).HasColumnType("nvarchar(max)");
        }
    }
}
