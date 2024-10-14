namespace ControllerLayer.DTOs {
    public class LearningExperienceDTO : BaseEntityDTO { 
        public string Title { get; set; } 
        public string Company { get; set; }  
        public AddressDTO Address { get; set; } 
        public string Description { get; set; }
    }
}
