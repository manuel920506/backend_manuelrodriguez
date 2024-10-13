using ModelLayer;
using ModelLayer.Queries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Interfaces {
    public interface IExperiencesSvc {
         LearningExperience[] GetAllLearningExperiences(LearningExperienceListQuery query);
    }
}
