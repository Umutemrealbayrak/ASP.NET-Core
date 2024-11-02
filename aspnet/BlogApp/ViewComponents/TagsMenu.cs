using BlogApp.Data.Abstract;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace BlogApp.ViewComponents
{
    
    public class TagsMenu: ViewComponent  
    {
        private ITagRepository _tagRepository;
         public TagsMenu(ITagRepository tagrepository)
         {
            _tagRepository=tagrepository;
         }

         public async Task<IViewComponentResult> InvokeAsync()
         {
            return View(await _tagRepository.Tags.ToListAsync());
         }
    }
}