using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor;
using Razor.Repository;

namespace razorpagesExample.Pages.Employees;

public class DetailsModel: PageModel
{
     private readonly IEmployessRepository _IEmployessRepository;
    public DetailsModel(IEmployessRepository IEmployessRepository)
    {
        _IEmployessRepository= IEmployessRepository;
    }
    public Employess employees{ get; set; }=default!;

    public IActionResult OnGet(int id)
    {
        employees = _IEmployessRepository.GetById(id);

        if(employees==null)
        {
            return RedirectToPage("/NotFound");
        }
        return Page();
    }
}