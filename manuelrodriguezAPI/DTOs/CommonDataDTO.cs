using System.ComponentModel.DataAnnotations; 
namespace ControllerLayer.DTOs {
    public class CommonDataDTO : BaseEntityDTO {

        [Required] 
        public string Code { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; } 
    }
}
