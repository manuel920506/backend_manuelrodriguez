using DataAccessLayer.Interfaces;
using ModelLayer; 
using ServiceLayer.Interfaces; 

namespace Services {
    public class SkillSvc : ISkillSvc {
        private readonly ISkill skills;
        public SkillSvc(ISkill skills) {
            this.skills = skills;
        }
        public async Task<Skill[]> GetAllSkills() {
            return await this.skills.GetAllSkills();
        }
    }
}
