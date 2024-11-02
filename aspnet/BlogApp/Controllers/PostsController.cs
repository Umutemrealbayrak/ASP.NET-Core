using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  BlogApp.Controllers
{

     public class PostsController : Controller
     {
        private  IPostRepository _postrepository;
        private  ICommentRepository _commentrepository;
        
        
        public PostsController(IPostRepository postrepository, ICommentRepository commentrepository)
        {
            _postrepository=postrepository; 
            _commentrepository=commentrepository;
        }
        public async Task<IActionResult> Index(string tag)
        {
            var posts=_postrepository.posts.Where(i=> (bool)i.isactive);
            if(!string.IsNullOrEmpty(tag))
            {
                 posts=posts.Where(x => x.tags.Any(t=> t.Url == tag));
            }
            return View(
                new PostsViewmodel
                {
                    Posts=await posts.ToListAsync()
                }
            );
        }
        
       public async Task<IActionResult> Details(string url)
       {
          return View(await _postrepository.posts.Include(x=>x.tags)
          .Include(x =>x.comments)
          .ThenInclude(x=>x.user)
          .FirstOrDefaultAsync(p =>p.Url == url));
       }
       
       public IActionResult AddComment(int PostId,string Text, string Url)
       {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            var username=User.FindFirstValue(ClaimTypes.Name);
            var avatar=User.FindFirstValue(ClaimTypes.UserData);
            var entity = new Comment{
                text=Text,
                publishedon=DateTime.Now,
                postId=PostId,
                userId=int.Parse(userId ?? "")
                
            };
            _commentrepository.CreateComment(entity);
           

            return RedirectToRoute("post_details",new { url = Url });
       }
       [Authorize]
       public IActionResult Create()
       {
         return View();
       }
       [HttpPost]
       public IActionResult Create(PostCreateViewmodel model)
       {
          if(ModelState.IsValid)
          {
            var userId=User.FindFirstValue(ClaimTypes.NameIdentifier);
            _postrepository.CreatePost(
                new Post{
                    title=model.title,
                    description=model.description,
                    content=model.content,
                    Url=model.Url,
                    userId=int.Parse(userId ?? ""),
                    publishedon=DateTime.Now,
                    Image="1.jpg",
                    isactive=false
                }
                
            );
            
            
            return RedirectToAction("index");

          }
          
          
          return View(model);
       }
       public async Task<IActionResult> List()
       {
         var userId=int.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier) ?? "");
         var role=User.FindFirstValue(ClaimTypes.Role);

         var post=_postrepository.posts;
         if(string.IsNullOrEmpty(role))
         {
            post=post.Where(i=>i.userId==userId);
         }

          
         return View(await post.ToListAsync());
       }
       [Authorize]
       public IActionResult Edit(int? id)
       {
          if(id==null)
          {
            return NotFound();
          }
          var post=_postrepository.posts.FirstOrDefault(i=>i.postId==id);
          if(post==null)
          {
            return NotFound();
          }
          return View(new PostCreateViewmodel
          {
            postId=post.postId,
            title=post.title,
            description=post.description,
            content=post.content,
            Url=post.Url,
            isactive=post.isactive
          });
       }
       [Authorize]
       [HttpPost]
       public IActionResult Edit(PostCreateViewmodel model)
       {
          if(ModelState.IsValid)
          {
              var entityToUpdate=new Post{
                  postId=model.postId,
                  title=model.title,
                  description=model.description,
                  content=model.content,
                  Url=model.Url,
                  isactive=model.isactive
              };
              if(User.FindFirstValue(ClaimTypes.Role)=="admin")
              {
                entityToUpdate.isactive=model.isactive;
              }
              _postrepository.EditPost(entityToUpdate);
              return RedirectToAction("List");
              
              
          }
          return View(model);
       }
       
     }


}