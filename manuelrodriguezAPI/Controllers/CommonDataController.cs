using AutoMapper;
using ControllerLayer.Caching;
using ControllerLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ServiceLayer.Interfaces;
using Services;

namespace backendAPI.Controllers {
    /// <summary/>
    [ApiController]
    [Route("api/[controller]")]
    public class CommonDataController : ControllerBase {
        private readonly ICommonDataSvc commonDataSvc;
        private readonly IEducationSvc educationSvc;
        private readonly IExperiencesSvc experiencesSvc;
        private readonly ISkillSvc skillSvc;
        private readonly IMapper mapper;

        public CommonDataController(
            ICommonDataSvc commonDataSvc,
            IEducationSvc educationSvc,
            IExperiencesSvc experiencesSvc,
            ISkillSvc skillSvc,
            IMapper mapper
            ) {
            this.commonDataSvc = commonDataSvc;
            this.educationSvc = educationSvc;
            this.experiencesSvc = experiencesSvc;
            this.skillSvc = skillSvc;
            this.mapper = mapper;
        }

         /// <summary>
         /// 
         /// </summary>
         /// <param name="searchTerm"></param>
         /// <returns></returns>
        [HttpGet]
        [OutputCache]
        [Route("GetCommonDataByDescriptionLikeMode", Name = "GetCommonDataByDescriptionLikeMode")]
        [ProducesResponseType(typeof(CommonDataDTO[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetCommonDataByDescriptionLikeMode([FromQuery] string searchTerm) {
            try {
                var commonData = await commonDataSvc.GetCommonDataByDescriptionLikeMode(searchTerm);
                CommonDataDTO[] commonDataDTO = commonData.Select(s => mapper.Map<CommonDataDTO>(s)).ToArray();
                return Ok(commonDataDTO);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [OutputCache]
        [Route("GetCommonDataByCode", Name = "GetCommonDataByCode")]
        [ProducesResponseType(typeof(CommonDataDTO), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetCommonDataByCode([FromQuery] string code) {
            try {
                var commonData = await commonDataSvc.GetCommonDataByCode(code);
                if (commonData == null) {
                    return NotFound();
                }
                CommonDataDTO commonDataDTO =  mapper.Map<CommonDataDTO>(commonData);
                return Ok(commonDataDTO);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        [HttpGet]
        [ServiceFilter(typeof(IpOutputCacheFilter))]
        [Route("GetInfoCV", Name = "GetInfoCV")]
        [ProducesResponseType(typeof(InfoCvDTO), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetInfoCV([FromQuery] string code) {
            try {
                var commonData = await commonDataSvc.GetCommonDataByCode(code);
                CommonDataDTO commonDataDTO = new CommonDataDTO();
                if (commonData != null) {
                    commonDataDTO = mapper.Map<CommonDataDTO>(commonData);
                }
                var educations = await educationSvc.GetAllEducations();
                EducationDTO[] educationsDTO = educations.Select(s => mapper.Map<EducationDTO>(s)).ToArray();
                var learningExperiences = await experiencesSvc.GetAllLearningExperiences();
                LearningExperienceDTO[] learningExperiencesDTO = learningExperiences.Select(le => mapper.Map<LearningExperienceDTO>(le)).ToArray();
                var skills = await skillSvc.GetAllSkills();
                SkillDTO[] skillsDTO = skills.Select(s => mapper.Map<SkillDTO>(s)).ToArray();

                InfoCvDTO infoCvDTO = new InfoCvDTO { 
                    commonDataDTO = commonDataDTO,
                    educationsDTO = educationsDTO,
                    learningExperiencesDTO = learningExperiencesDTO,
                    skillsDTO = skillsDTO
                };

                return Ok(infoCvDTO);
            } catch (Exception ex) {
                return BadRequest(ex.Message);
            }
        }
    }
}
