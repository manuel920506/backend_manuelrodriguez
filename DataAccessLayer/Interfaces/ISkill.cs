namespace DataAccessLayer.Interfaces {
    public interface ISkill {
        Task<ModelLayer.Skill[]> GetAllSkills();
    }
}
