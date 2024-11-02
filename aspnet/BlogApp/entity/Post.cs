using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.entity
{
    public class Post
    {
        public int postId { get; set; }
        public string? title { get; set; }
        public string? description { get; set; }
        public string? content { get; set; }
        public string? Url { get; set; }
        public string? Image { get; set; }
        public DateTime? publishedon { get; set; }
        public bool? isactive { get; set; }
        public int? userId { get; set;}
        public User user{ get; set; }=null!;
        public List<Tag> tags{ get; set; } = new List<Tag>();
        public List<Comment> comments{ get; set; } = new List<Comment>();
    }
}