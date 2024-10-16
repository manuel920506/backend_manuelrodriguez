using ModelLayer;
namespace ServiceLayer.Interfaces {
    public interface IExperiencesSvc {
        Task<LearningExperience[]> GetAllLearningExperiences();
    }
}
