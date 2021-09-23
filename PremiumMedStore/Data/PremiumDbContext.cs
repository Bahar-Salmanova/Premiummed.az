using PremiumMedStore.Models;
using Microsoft.EntityFrameworkCore;


namespace PremiumMedStore.Data
{
    public class PremiumDbContext: DbContext
    {
        public PremiumDbContext(DbContextOptions<PremiumDbContext> options) : base(options)
        {

        }
        public DbSet<Clients> Clients { get; set; }
        public DbSet<Galery> Galeries { get; set; }
        public DbSet<IndexProduct> IndexProducts { get; set; }
        public DbSet<Measure> Measures { get; set; }
        public DbSet< News> News { get; set; }
        public DbSet<ProductOrder> ProductOrders { get; set; }
        public DbSet<Products> Products { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SosialLinks> SosialLinks { get; set; }
        public DbSet<Vacancy> Vacancies { get; set; }
        public DbSet<VacancyForm> VacancyForms { get; set; }
        public DbSet<Welcome> Welcomes { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
