using System.ComponentModel.DataAnnotations;
namespace ModelLayer {
    public class CommonData : BaseEntity {
        [Required]
        public string Code { get; set; }

        [Required]
        [StringLength(3000)]
        public string Description { get; set; }
    }
}
