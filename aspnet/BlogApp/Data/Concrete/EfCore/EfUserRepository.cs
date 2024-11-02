using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.entity;

namespace BlogApp.Data.Concrete
{
    public class EfUserRepository : IUserRepository
    {
        private BlogContext _context;

        public EfUserRepository(BlogContext context)
        {
            _context=context;
        }
        public IQueryable<User> users => _context.Users;

        public void CreateUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();

        }

        
    }
}