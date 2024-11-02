using System.ComponentModel.DataAnnotations;
using BlogApp.entity;

namespace BlogApp.Models
{
    public class RegisterViewmodel
    {
        [Required]
        [Display(Name = "username")]
        public string? username { get; set;}
        [Required]
        [Display(Name ="AD SOYAD")]
        public string? name { get; set;}
        
        
        [Required]
        [EmailAddress]
        [Display(Name = "Eposta")]
       public string? email { get; set; }

       [Required]
       [StringLength(6, ErrorMessage = "maksimum 10 karater")]
       [DataType(DataType.Password)]
       [Display(Name = "Parola")]
       public string? password { get; set; }

       [Required]
       [DataType(DataType.Password)]
       [Compare (nameof(password))]
       [Display(Name = "Parola")]
       public string? confirmpassword { get; set; }

    
    }
    
}