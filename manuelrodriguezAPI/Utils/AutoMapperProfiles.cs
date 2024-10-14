﻿using AutoMapper;
using ControllerLayer.DTOs;
using ControllerLayer.DTOs.Queries;
using ModelLayer;
using ModelLayer.Queries;

namespace ControllerLayer.Utils {
    public class AutoMapperProfiles: Profile {
        public AutoMapperProfiles() {
            ConfigLearningExperienceMapping();
        }

        private void ConfigLearningExperienceMapping() {
            CreateMap<LearningExperienceDTO, LearningExperience>();
            CreateMap<LearningExperience, LearningExperienceDTO>();
            CreateMap<Address, AddressDTO>();
            CreateMap<AddressDTO, Address>();
            CreateMap<LearningExperienceListQueryDTO, LearningExperienceListQuery>();
        }
    }
}