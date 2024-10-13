using ModelLayer.Queries;
using ModelLayer; 

namespace DataAccessLayer.Interfaces {
    public interface ILearningExperiences {
         LearningExperience[] GetAllLearningExperiences(LearningExperienceListQuery query);
    }
}
