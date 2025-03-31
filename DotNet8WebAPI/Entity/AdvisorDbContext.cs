using DotNet8WebAPI.Model;
using Microsoft.EntityFrameworkCore;

namespace DotNet8WebAPI.Entity
{
    public class AdvisorDbContext : DbContext
    {
        public AdvisorDbContext(DbContextOptions<AdvisorDbContext> options) : base(options) { }        
        public DbSet<Advisor> Advisors { get; set; }

        public DbSet<InvestmentUser> InvestmentUser { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Advisor>().HasKey(x=>x.Id);

            modelBuilder.Entity<Advisor>().HasData(
                 new Advisor()
                 {
                     Id = 1,
                     FirstName = "Geeta",
                     LastName = "Sharma",
                     IsActive = true
                 },
                new Advisor()
                {
                    Id = 2,
                    FirstName = "Ram",
                    LastName = "Pratap",
                    IsActive = true
                },
                new Advisor()
                {
                    Id = 3,
                    FirstName = "Shreya",
                    LastName = "Sharma",
                    IsActive = true
                },
                new Advisor()
                {
                    Id = 4,
                    FirstName = "Dewang",
                    LastName = "Parashar",
                    IsActive = true
                });

            modelBuilder.Entity<InvestmentUser>().HasData(
                new InvestmentUser()
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    Username = "System",
                    Password = "System",
                });
        }

    }
}
