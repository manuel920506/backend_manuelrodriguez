using Microsoft.EntityFrameworkCore;
using ModelLayer;
using System.Xml;

namespace DataAccessLayer {
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Add-Migration LearningExperienceTable
        //Add-Migration AddAddressTable

        //Update-Database
        public DbSet<LearningExperience> LearningExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}
