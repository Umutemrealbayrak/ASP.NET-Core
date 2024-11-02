namespace Razor.Repository;

public interface IEmployessRepository
{
    IEnumerable<Employess> GetAll();

    Employess GetById(int id);
    Employess Update(Employess entity);
}