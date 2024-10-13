using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;
namespace ModelLayer {
    public class LearningExperience: BaseEntity {
        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [Required]
        [StringLength(250)]
        public string Company { get; set; }

        [Required] 
        [ForeignKey("Address")]
        public int AddressId { get; set; }

        // Proprietà di navigazione
        [JsonIgnore]
        public Address Address { get; set; }

        [Required]
        [StringLength(1000)]
        public string Description { get; set; }
    }
}
