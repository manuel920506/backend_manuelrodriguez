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
    public class SkillController : ControllerBase {
        private readonly ISkillSvc skillSvc;
        private readonly IMapper mapper;

        public SkillController(
            ISkillSvc skillSvc, IMapper mapper
            ) {
            this.skillSvc = skillSvc;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [OutputCache]
        [Route("GetAllSkills", Name = "GetAllSkills")] 
        [ProducesResponseType(typeof(SkillDTO[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAllSkills() {
            try {
                var skills = await skillSvc.GetAllSkills();
                SkillDTO[] skillsDTO = skills.Select(s=> mapper.Map<SkillDTO>(s)).ToArray();
                return Ok(skillsDTO); 
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
