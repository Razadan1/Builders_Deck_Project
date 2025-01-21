using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Builders_Deck.Data
{
    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : IdentityDbContext(options)
    {
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            builder.Entity<Project>().HasData(
        new Project { Id = 1, Title = "Luxury Villa", Description = "Completed by XYZ Constructions", ImageUrl = "/images/villa.jpg", CompletionDate = DateTime.Now.AddDays(-30), ContractorName = "XYZ Constructions" },
        new Project { Id = 2, Title = "Modern Office", Description = "Completed by ABC Builders", ImageUrl = "/images/office.jpg", CompletionDate = DateTime.Now.AddDays(-60), ContractorName = "ABC Builders" }
    );
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Contractor> Contractors { get; set; }
    }
}
