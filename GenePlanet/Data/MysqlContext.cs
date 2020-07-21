using GenePlanet.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GenePlanet.Data
{
    public class MysqlContext : DbContext
    {
        public MysqlContext(DbContextOptions<MysqlContext> options)
            : base(options)
        {
        }

        public DbSet<BreachedEmail> BreachedEmails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BreachedEmail>(entity => {
                entity.ToTable("breached_emails");
                entity.HasKey(email => email.Id);
                entity.HasIndex(email => email.Email).IsUnique();
            });
        }
    }
}
