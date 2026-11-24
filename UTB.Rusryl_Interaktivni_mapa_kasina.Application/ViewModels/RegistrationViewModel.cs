using System.ComponentModel.DataAnnotations;

namespace UTB.Rusryl_Interaktivni_mapa_kasina.Application.ViewModels
{
    public class RegistrationViewModel
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? ZipCode { get; set; }
        public string? Country { get; set; }
 
        [Required]
        public string? Username { get; set; }

        [Required]
        [EmailAddress]
        public string? Email { get; set; }

        [Phone]
        public string? Phone { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        [Compare(nameof(Password), ErrorMessage = "Passwords don't match.")]
        public string? RepeatedPassword { get; set; }
    }
}
