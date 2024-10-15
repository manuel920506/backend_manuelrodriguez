using ModelLayer;
using ModelLayer.Queries; 

namespace ServiceLayer.Interfaces {
    public interface IExperiencesSvc {
         LearningExperience[] GetAllLearningExperiences(LearningExperienceListQuery query);
    }
}
