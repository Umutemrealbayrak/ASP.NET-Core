using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.entity
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string? text { get; set;}
        public DateTime? publishedon { get; set; }
        public int postId { get; set; }
        public Post post{ get; set; } = null!;
        public int? userId { get; set;}
        public User user{ get; set; }=null!;
    }
}