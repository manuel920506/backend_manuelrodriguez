using DataAccessLayer.Interfaces;
using ModelLayer;
using ModelLayer.Queries;
using ServiceLayer.Interfaces; 

namespace Services {
    public class ExperiencesSvc : IExperiencesSvc {
        private readonly ILearningExperiences _learningExperiences;
        public ExperiencesSvc(ILearningExperiences learningExperiences) {
            _learningExperiences = learningExperiences;
        }
        public async Task<LearningExperience[]> GetAllLearningExperiences(LearningExperienceListQuery query) {
            return await  _learningExperiences.GetAllLearningExperiences(query);
        }
    }
}
