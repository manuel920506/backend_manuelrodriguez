using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ModelLayer; 

namespace DataAccessLayer {
    public class ApplicationDbContext: IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //Add-Migration LearningExperienceTable
        //Add-Migration AddAddressTable
        //Add-Migration AddSkillTable
        //Add-Migration UserSystem

        //Update-Database
        public DbSet<LearningExperience> LearningExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<ModelLayer.Skill> Skills { get; set; }
    }
}
