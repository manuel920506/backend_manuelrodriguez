using ModelLayer;
using ModelLayer.Queries; 

namespace ServiceLayer.Interfaces {
    public interface IExperiencesSvc {
        Task<LearningExperience[]> GetAllLearningExperiences(LearningExperienceListQuery query);
    }
}
