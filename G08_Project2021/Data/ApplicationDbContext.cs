using G08_Project2021.Models;
using G08_Project2021.Models.Domein;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace G08_Project2021.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Contract> Contracten { get; set; }
        public DbSet<Gebruiker> Gebruikers { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<Poging> Pogingen { get; set; }
        public DbSet<ContractType> ContractTypes { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            
        }
    }
}
