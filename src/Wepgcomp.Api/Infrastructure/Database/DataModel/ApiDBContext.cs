using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.Workshops;
using Wepgcomp.Api.Infrastructure.Database.DataModel.Models.WorkshopSessions;

namespace Wepgcomp.Api.Infrastructure.Database
{
    public class ApiDBContext : DbContext
    {
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopSession> Sessions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Workshop>().Configure();
            modelBuilder.Entity<WorkshopSession>().Configure();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                        .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                        .AddJsonFile("appsettings.json")
                        .Build();

            var serverVersion = new MySqlServerVersion(new Version(8, 0, 23));
            optionsBuilder.UseMySql(configuration.GetConnectionString("DefaultConnection"), serverVersion);
        }
    }
}
