﻿using AutoMapper;
using ControllerLayer.DTOs;
using ControllerLayer.DTOs.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ModelLayer;
using ModelLayer.Queries;
using ServiceLayer.Interfaces;
using System.Xml.Linq;

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
        [HttpPost]
        [Route("GetAllLearningExperiences", Name = "GetAllLearningExperiences")]
        //[Authorize]
        [ProducesResponseType(typeof(LearningExperienceDTO[]), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public IActionResult GetAllLearningExperiences(LearningExperienceListQueryDTO query) {
            try {
                var _query = mapper.Map<LearningExperienceListQuery>(query);
                var learningExperiences = experiencesSvc.GetAllLearningExperiences(_query);
                LearningExperienceDTO[] learningExperiencesDTO = learningExperiences.Select(le => mapper.Map<LearningExperienceDTO>(le)).ToArray();
                return Ok(learningExperiencesDTO); 
            } catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }
    }
}