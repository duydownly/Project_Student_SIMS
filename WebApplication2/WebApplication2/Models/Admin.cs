using System.ComponentModel.DataAnnotations;

namespace WebApplication2.Models
{
    public class Admin
    {
        public int Id { get; set; } // Unique ID for each admin

        [Required]
        [EmailAddress]
        public string Email { get; set; } // Admin's email

        [Required]
        public string Password { get; set; } // Admin's password (use hashed passwords in real applications)

        // You can add additional properties, such as Name, Role, etc.
    }
}
