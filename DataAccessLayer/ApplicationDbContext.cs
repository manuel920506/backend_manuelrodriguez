using Microsoft.EntityFrameworkCore;
using ModelLayer; 

namespace DataAccessLayer {
    public class ApplicationDbContext: DbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Add-Migration LearningExperienceTable
        //Add-Migration AddAddressTable
        //Add-Migration AddSkillTable

        //Update-Database
        public DbSet<LearningExperience> LearningExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<ModelLayer.Skill> Skills { get; set; }
    }
}
