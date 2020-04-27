using System;
using CCB.Domain.Model;
using CCB.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace CCB.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        private const string ConnectionString = "ConnectionString";
        public DbSet<Extrato> Extrato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var configuration = new ConfigurationBuilder()
                    .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                    .AddJsonFile("appsettings.json")
                    .Build();
                optionsBuilder.UseMySql(configuration[ConnectionString]);
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Extrato>(new ExtratoMap().Configure);
        }
    }
}