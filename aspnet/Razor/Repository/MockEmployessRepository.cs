namespace Razor.Repository;


public class MockEmployessRepository : IEmployessRepository
{
    private List<Employess> _employessList;
    public MockEmployessRepository()
    {
        _employessList = new List<Employess>(){
            new Employess{Id=1, Name="umut", Email="umutemrealbayrak@gmail.com",photo="1.jpg",departmant="software"},
            new Employess{Id=2, Name="emre", Email="emrealbayrak@gmail.com",photo="2.jpg",departmant="software"},
            new Employess{Id=3, Name="enes", Email="enesalbayrak@gmail.com",photo="3.jpg",departmant="software"},
            new Employess{Id=4, Name="elif", Email="eliflbayrak@gmail.com",photo="4jpg",departmant="software"}
        };
    }
    public IEnumerable<Employess> GetAll()
    {
        return _employessList;
    }

    public Employess GetById(int id)
    {
        return _employessList.FirstOrDefault(a => a.Id == id);
    }

    public Employess Update(Employess entity)
    {
        Employess employee = _employessList.FirstOrDefault(i => i.Id == entity.Id);

        if(employee != null)
        {
            employee.Name = entity.Name;
            employee.Email = entity.Email;
            employee.photo = entity.photo;
            employee.departmant = entity.departmant;
        }
        return employee;
    }
}