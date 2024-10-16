using System.ComponentModel.DataAnnotations; 
namespace ControllerLayer.DTOs {
    public class SkillDTO : BaseEntityDTO {

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        public string pathProject { get; set; }

        public int Weight { get; set; }
    }
}
