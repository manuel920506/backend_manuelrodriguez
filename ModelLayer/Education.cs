using System.ComponentModel.DataAnnotations;
namespace ModelLayer {
    public class Education : BaseEntity {

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }

        [Required]
        public string SchoolName { get; set; }

        [Required]
        public string SchoolAddress { get; set; }
    }
}
