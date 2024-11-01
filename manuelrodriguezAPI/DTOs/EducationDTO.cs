using System.ComponentModel.DataAnnotations; 
namespace ControllerLayer.DTOs {
    public class EducationDTO : BaseEntityDTO {

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string SchoolAddress { get; set; }
    }
}
