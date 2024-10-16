using ModelLayer; 

namespace ServiceLayer.Interfaces {
    public interface ISkillSvc {
        Task<Skill[]> GetAllSkills();
    }
}
