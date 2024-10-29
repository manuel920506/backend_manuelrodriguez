using AutoMapper;
using ControllerLayer.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OutputCaching;
using ServiceLayer.Interfaces;

namespace backendAPI.Controllers {
    /// <summary/>
    [ApiController]
    [Route("api/[controller]")]
    public class CommonDataController : ControllerBase {
        private readonly ICommonDataSvc commonDataSvc;
        private readonly IMapper mapper;

        public CommonDataController(
            ICommonDataSvc commonDataSvc, IMapper mapper
            ) {
            this.commonDataSvc = commonDataSvc;
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
    }
}
