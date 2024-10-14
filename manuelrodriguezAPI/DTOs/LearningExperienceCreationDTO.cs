using ModelLayer;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ControllerLayer.DTOs {
    public class LearningExperienceCreationDTO : BaseEntityDTO {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Company { get; set; }

        [Required]
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        public Address Address { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
