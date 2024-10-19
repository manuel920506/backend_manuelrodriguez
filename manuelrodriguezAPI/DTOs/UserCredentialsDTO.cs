using System.ComponentModel.DataAnnotations;

namespace ControllerLayer.DTOs {
    public class UserCredentialsDTO {
        [EmailAddress]
        [Required]
        public required string Email { get; set; }
        [Required]
        public required string Password { get; set; }
    }
}
