using System.ComponentModel.DataAnnotations;

namespace API.Models
{
    public class ClientsDto
    {
        [Required(ErrorMessage = "Firstname is required")]
        public string FirstName { get; set; } = "";

        [Required(ErrorMessage = "LastName is required")]
        public string LastName { get; set; } = "";

        [Required, EmailAddress]
        public string Email { get; set; } = "";

        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Address { get; set; }

        [Required]
        public string Status { get; set; } = "";
    }
}
