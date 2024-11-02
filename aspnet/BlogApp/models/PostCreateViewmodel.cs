using System.ComponentModel.DataAnnotations;
using BlogApp.entity;

namespace BlogApp.Models
{
    public class PostCreateViewmodel
    {
        public int postId { get; set; }
        [Required]
        [Display(Name = "başlık")]
       public string? title { get; set; }

       [Required]
       [Display(Name = "içerik")]
       public string? description { get; set; }
       [Required]
       [Display(Name = "geneliçereik")]
       public string? content { get; set; }
       [Required]
       [Display(Name = "Url")]
       public string? Url { get; set; }
       public bool? isactive { get; set; }

    
    }
    
}