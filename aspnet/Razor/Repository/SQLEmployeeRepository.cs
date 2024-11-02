using Razor;
using Razor.Repository;
using razorpagesExample.Models;

namespace razorpagesExample;

public class SQLEmployeeRepository : IEmployessRepository
{
    private readonly DataContext _context;
    public SQLEmployeeRepository(DataContext context)
    {
        _context = context;
    }
    public IEnumerable<Employess> GetAll()
    {
        return _context.Employees.ToList();
    }


    public Employess GetById(int id)
    {
        return _context.Employees.FirstOrDefault(a => a.Id == id);
    }

    public Employess Update(Employess entity)
    {
        var entityToUpdate = _context.Employees.FirstOrDefault(i => i.Id == entity.Id);

       if(entityToUpdate != null)
       {
            entityToUpdate.Name = entity.Name;
            entityToUpdate.Email = entity.Email;
            entityToUpdate.departmant = entity.departmant;
            entityToUpdate.photo = entity.photo;
            _context.SaveChanges();
       }
       return entityToUpdate;
    }
}