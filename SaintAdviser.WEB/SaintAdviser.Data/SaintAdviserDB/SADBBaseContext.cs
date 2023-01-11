using Microsoft.EntityFrameworkCore;
using SaintAdviser.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SaintAdviser.Data.SaintAdviserDB
{
    public abstract class SADBBaseContext : DbContext
    {
        public SADBBaseContext(DbContextOptions dbContext) : base(dbContext) { }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>().HasKey(c => c.Id);
            modelBuilder.Entity<Contact>().ToTable("Contacts");

            modelBuilder.Entity<EuropeServiceRequest>().HasKey(c => c.Id);
            modelBuilder.Entity<EuropeServiceRequest>().ToTable("EuropeServiceRequests");

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Contact> Contacts { get; set; }
        public DbSet<EuropeServiceRequest> EuropeServiceRequests { get; set; }
    }
}
