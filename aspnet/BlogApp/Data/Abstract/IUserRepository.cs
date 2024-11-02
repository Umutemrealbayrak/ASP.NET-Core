using BlogApp.entity;
namespace BlogApp.Data.Abstract
{
    public interface IUserRepository
    {
        IQueryable<User> users { get; }
        void CreateUser (User user);
    }
}