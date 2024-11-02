using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.entity;

namespace BlogApp.Data.Concrete
{
    public class EfPostRepository : IPostRepository
    {
        private BlogContext _context;

        public EfPostRepository(BlogContext context)
        {
            _context=context;
        }

      

        public IQueryable<Post> posts => _context.Posts;

        public void CreatePost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();

        }

        public void EditPost(Post post)
        {
            var entity = _context.Posts.FirstOrDefault(i=>i.postId == post.postId);

            if (entity != null)
            {
                  entity.title = post.title;
                  entity.description = post.description;
                  entity.comments = post.comments;
                  entity.Url = post.Url;
                  entity.isactive = post.isactive;

                  _context.SaveChanges();
            }
        }
    }
}