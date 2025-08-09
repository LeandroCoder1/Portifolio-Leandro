using System.ComponentModel.DataAnnotations;

namespace Portifolio_Leandro.Models
{
    public class ContactModel
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;
        public string? Subject { get; set; }

        [Required]
        public string Message { get; set; } = string.Empty;
    }
}
