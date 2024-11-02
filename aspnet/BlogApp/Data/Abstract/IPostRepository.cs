using BlogApp.entity;
namespace BlogApp.Data.Abstract
{
    public interface IPostRepository
    {
        IQueryable<Post> posts { get; }
        void CreatePost (Post post);
        void EditPost (Post post);
        
    }
}