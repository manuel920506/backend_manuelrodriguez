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
    public class EducationController : ControllerBase {
        private readonly IEducationSvc educationSvc;
        private readonly IMapper mapper;

        public EducationController(
            IEducationSvc educationSvc, IMapper mapper
            ) {
            this.educationSvc = educationSvc;
            this.mapper = mapper;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [OutputCache]
        [Route("GetAllEducations", Name = "GetAllEducations")] 
        [ProducesResponseType(typeof(EducationDTO[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> GetAllEducations() {
            try {
                var educations = await educationSvc.GetAllEducations();
                EducationDTO[] educationsDTO = educations.Select(s=> mapper.Map<EducationDTO>(s)).ToArray();
                return Ok(educationsDTO); 
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}
