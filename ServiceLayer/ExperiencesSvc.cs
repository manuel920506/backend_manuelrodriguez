using DataAccessLayer.Interfaces;
using ModelLayer; 
using ServiceLayer.Interfaces; 

namespace Services {
    public class ExperiencesSvc : IExperiencesSvc {
        private readonly ILearningExperiences learningExperiences;
        public ExperiencesSvc(ILearningExperiences learningExperiences) {
            this.learningExperiences = learningExperiences;
        }
        public async Task<LearningExperience[]> GetAllLearningExperiences() {
            return await this.learningExperiences.GetAllLearningExperiences();
        }
    }
}
