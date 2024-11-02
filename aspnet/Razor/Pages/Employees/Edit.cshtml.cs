using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Razor;
using Razor.Repository;

namespace razorpagesExample.Pages.Employees;

public class EditModel: PageModel
{
     private readonly IEmployessRepository _IEmployessRepository;
    public EditModel(IEmployessRepository IEmployessRepository)
    {
        _IEmployessRepository= IEmployessRepository;
    }
    //[BindProperty]
    public Employess employees{ get; set; }=default!;

    public void OnGet(int id)
    {
        employees = _IEmployessRepository.GetById(id);
        
    }
    public IActionResult OnPost(Employess employees)
     {
         employees = _IEmployessRepository.Update(employees);
         return RedirectToPage("/Employees/Index");
     }
     /* public IActionResult OnPost()
    {
        employees = _IEmployessRepository.Update(employees);
        return RedirectToPage("/Employees/Index");
    }*/
}