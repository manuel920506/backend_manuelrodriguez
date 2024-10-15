using ModelLayer; 

namespace DataAccessLayer.Interfaces {
    public interface ILearningExperiences {
        Task<LearningExperience[]> GetAllLearningExperiences();
    }
}
