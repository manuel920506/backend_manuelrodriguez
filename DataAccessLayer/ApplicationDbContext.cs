using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using ModelLayer; 

namespace DataAccessLayer {
    public class ApplicationDbContext: IdentityDbContext {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder) {
        //    base.OnModelCreating(modelBuilder);
        //    modelBuilder.Entity<MyEntity>().HasKey(e => new { e.key1, e.key2 });
        //}

        //Add-Migration LearningExperienceTable
        //Add-Migration AddAddressTable
        //Add-Migration AddSkillTable
        //Add-Migration UserSystem
        //Add-Migration Educations
        //Add-Migration CommonData
        //Add-Migration UpdateEducations
        //Add-Migration UserActivityLogs

        //Update-Database
        public DbSet<LearningExperience> LearningExperiences { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<ModelLayer.Skill> Skills { get; set; }

        public DbSet<ModelLayer.Education> Educations { get; set; }

        public DbSet<ModelLayer.CommonData> CommonData { get; set; }

        public DbSet<ModelLayer.UserActivityLog> UserActivityLogs { get; set; }
    }
}
