using AutoMapper;
using ControllerLayer.DTOs; 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching; 
using ServiceLayer.Interfaces; 

namespace backendAPI.Controllers
{
    /// <summary/>
    [ApiController]
    [Route("api/[controller]")]
    public class LearningExperienceController : ControllerBase {
        private readonly IExperiencesSvc experiencesSvc;
        private readonly IMapper mapper;

        public LearningExperienceController(
            IExperiencesSvc experiencesSvc, IMapper mapper
            ) {
            this.experiencesSvc = experiencesSvc;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [OutputCache]
        [Route("GetAllLearningExperiences", Name = "GetAllLearningExperiences")] 
        [ProducesResponseType(typeof(LearningExperienceDTO[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAllLearningExperiences() {
            try {
                var learningExperiences = await experiencesSvc.GetAllLearningExperiences();
                LearningExperienceDTO[] learningExperiencesDTO = learningExperiences.Select(le => mapper.Map<LearningExperienceDTO>(le)).ToArray();
                return Ok(learningExperiencesDTO); 
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
