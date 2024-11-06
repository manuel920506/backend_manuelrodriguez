namespace ControllerLayer.DTOs {
    public class InfoCvDTO {
        public CommonDataDTO commonDataDTO { get; set; }
        public EducationDTO[] educationsDTO { get; set; }
        public LearningExperienceDTO[] learningExperiencesDTO { get; set; }
        public SkillDTO[] skillsDTO { get; set; }
    }
}
