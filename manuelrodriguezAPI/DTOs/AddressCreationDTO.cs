using System.ComponentModel.DataAnnotations;

namespace ControllerLayer.DTOs {
    public class AddressCreationDTO : EntityKeyIntDTO {
        [Required]
        [StringLength(100, ErrorMessage = "Street name cannot exceed 100 characters.")]
        public string Street { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "City name cannot exceed 50 characters.")]
        public string City { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "State name cannot exceed 50 characters.")]
        public string State { get; set; }

        [Required]
        [RegularExpression(@"^\d{5}(-\d{4})?$", ErrorMessage = "Invalid ZIP code format.")]
        public string ZipCode { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Country name cannot exceed 50 characters.")]
        public string Country { get; set; }
    }
}
