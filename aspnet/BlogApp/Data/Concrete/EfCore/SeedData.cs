using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.entity;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.Data.Concrete.EfCore
{
    public class SeedData
    {
        public static void TestVerileriniDoldur(IApplicationBuilder app)
        {
            var context = app.ApplicationServices.CreateScope().ServiceProvider.GetService<BlogContext>();
        
            if (context != null)
            {
                if (context.Database.GetPendingMigrations().Any())
                {
                    context.Database.Migrate();
                }
                if(!context.Tags.Any())
                {
                    context.Tags.AddRange(
                        new entity.Tag {text="web programlama",Url="web-programlama",Color=entity.Tagcolors.success},
                        new entity.Tag {text="backend",Url="backend",Color=entity.Tagcolors.primary},
                        new entity.Tag {text="frontend",Url="frontend",Color=entity.Tagcolors.warning},
                        new entity.Tag {text="fullstacak",Url="fullstack",Color=entity.Tagcolors.secondary},
                        new entity.Tag {text="php",Url="php",Color=entity.Tagcolors.danger}
                    );
                    context.SaveChanges();
                    
                }
                if(!context.Users.Any())
                {
                    context.Users.AddRange(
                        new entity.User {username="umutalbayrak",name="umut albayrak",email="qwer@gmail.com",password="987654", Image="1.jpg"},
                        new entity.User {username="emrealbayrak",name="emre albayrak",email="qwert@gmail.com",password="987653",Image="2.jpg"}
                    );
                    context.SaveChanges();
                    
                }
                if(!context.Posts.Any())
                {
                    context.Posts.AddRange(
                        new entity.Post {title="aspnet kursu",
                        description="aspnet dersleri",
                        content="aspnet dersleri",
                        Url="aspnet-core",
                        Image="1.jpg",
                        isactive=true,
                        publishedon=DateTime.Now.AddDays(-10),
                        tags=context.Tags.Take(4).ToList(),
                        userId=1,
                        comments=new List<Comment>{
                            new Comment {text="güzel",publishedon=new DateTime(),userId=1},
                            new Comment {text="kötü",publishedon=new DateTime(),userId=2}
                        }
                        }
                    
                    );
                    context.Posts.AddRange(
                        new entity.Post {title="php kursu",
                        description="php dersleri",
                        content="php dersleri",
                        Url="php",
                        Image="2.jpg",
                        isactive=true,
                        publishedon=DateTime.Now.AddDays(-20),
                        tags=context.Tags.Take(4).ToList(),
                        userId=1,
                        comments=new List<Comment>{
                            new Comment {text="güzel",publishedon=new DateTime(),userId=1},
                            new Comment {text="kötü",publishedon=new DateTime(),userId=2}
                        }
                        }
                    
                    );
                    context.Posts.AddRange(
                        new entity.Post {title="django kursu",
                        description="django dersleri",
                        content="django dersleri",
                        Url="django",
                        Image="3.jpg",
                        isactive=true,
                        publishedon=DateTime.Now.AddDays(-5),
                        tags=context.Tags.Take(4).ToList(),
                        userId=2,
                        comments=new List<Comment>{
                            new Comment {text="güzel",publishedon=new DateTime(),userId=1},
                            new Comment {text="kötü",publishedon=new DateTime(),userId=2}
                        }
                        }
                    
                    );
                    context.SaveChanges();
                    
                }
            }
        
        }
       
    }
}