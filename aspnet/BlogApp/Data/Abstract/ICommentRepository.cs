using BlogApp.entity;
namespace BlogApp.Data.Abstract
{
    public interface ICommentRepository
    {
        IQueryable<Comment> comments { get; }
        void CreateComment (Comment comment);
    }
}