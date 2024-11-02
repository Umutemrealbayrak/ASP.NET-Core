using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor.Repository;

namespace Razor.Pages.Employees;

public class IndexModel : PageModel
{
   
    public IEnumerable<Employess> employesss=new List<Employess>();
    private readonly IEmployessRepository _IEmployessRepository;
    public IndexModel(IEmployessRepository IEmployessRepository)
    {
        _IEmployessRepository= IEmployessRepository;
    }
    public void OnGet()
    {
        employesss=_IEmployessRepository.GetAll();   
    }
}
