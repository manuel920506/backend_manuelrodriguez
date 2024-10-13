using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.Queries;
using ServiceLayer.Interfaces; 

namespace backendAPI.Controllers {
    /// <summary/>
    [ApiController]
    [Route("api/[controller]")]
    public class LearningExperienceController : ControllerBase {
        private readonly IExperiencesSvc _experiencesSvc;

        public LearningExperienceController(IExperiencesSvc experiencesSvc) {
            _experiencesSvc = experiencesSvc;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [Route("GetAllLearningExperiences", Name = "GetAllLearningExperiences")]
        //[Authorize]
        [ProducesResponseType(typeof(LearningExperience[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetAllLearningExperiences(LearningExperienceListQuery query) {
             return Ok(_experiencesSvc.GetAllLearningExperiences(query)); 
        }
    }
}
