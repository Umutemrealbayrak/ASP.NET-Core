using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.entity
{
    public class User
    {
        public int userId { get; set;}
        public string? username { get; set;}
        public string? name { get; set;}
        public string? email { get; set;}   
        public string? password { get; set;}
        public string? Image { get; set; }
        public List<Post> posts { get; set;}=new List<Post>();
        public List<Comment> comments{ get; set;}=new List<Comment>();
    }
}