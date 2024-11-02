using System.ComponentModel.DataAnnotations;

namespace ProductsAPI.DTO
{
    public class UserDTO
    {
        [Required]
        public string? FullName { get; set; }
        public string? UserName { get; set;}
        public string? Email { get; set; }
        public string? Password { get; set; }

    }   
}