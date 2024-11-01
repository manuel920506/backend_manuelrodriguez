using DataAccessLayer.Interfaces;
using ModelLayer; 
using ServiceLayer.Interfaces; 

namespace Services {
    public class EducationSvc : IEducationSvc {
        private readonly IEducation education;
        public EducationSvc(IEducation education) {
            this.education = education;
        }
        public async Task<Education[]> GetAllEducations() {
            return await this.education.GetAllEducations();
        }
    }
}
