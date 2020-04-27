using CCB.Domain.Model;
using CCB.Infra.Data.Mapping;
using Microsoft.EntityFrameworkCore;

namespace CCB.Infra.Data.Context
{
    public class MySqlContext : DbContext
    {
        public DbSet<Extrato> Extrato { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseMySql("Server=localhost;Database=ccb;Uid=admin;Pwd=GMS123;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Extrato>(new ExtratoMap().Configure);
        }
    }
}