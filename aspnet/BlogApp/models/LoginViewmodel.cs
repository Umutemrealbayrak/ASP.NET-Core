using System.ComponentModel.DataAnnotations;
using BlogApp.entity;

namespace BlogApp.Models
{
    public class LoginViewmodel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
       public string? email { get; set; }

       [Required]
       [StringLength(6, ErrorMessage = "maksimum 10 karater")]
       [DataType(DataType.Password)]
       [Display(Name = "Parola")]
       public string? password { get; set; }

    
    }
    
}