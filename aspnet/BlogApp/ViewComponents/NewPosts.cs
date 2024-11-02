using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    public class NewPosts :ViewComponent
    {
        private IPostRepository _postRepository;
         public NewPosts(IPostRepository postrepository)
         {
            _postRepository=postrepository;
         }
          public async Task<IViewComponentResult> InvokeAsync()
         {
            return View(await _postRepository
            .posts
            .OrderByDescending(p=>p.publishedon)
            .Take(5)
            .ToListAsync());
         }

    }   
}