using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogApp.entity
{
    public enum Tagcolors
    {
        primary,danger,warning,success,secondary
    }
    public class Tag
    {
        public int tagId { get; set;}
        public string? text { get; set;}
        public string? Url { get; set; }
        public Tagcolors? Color { get; set; }

        public List<Post> posts { get; set;}=new List<Post>();
    }
}