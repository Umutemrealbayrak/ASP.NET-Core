using System.Security.Claims;
using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using BlogApp.entity;
using BlogApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace  BlogApp.Controllers
{

     public class UsersController : Controller
     {
        private readonly IUserRepository _userRepository;
        public UsersController(IUserRepository userRepository)
        {
            _userRepository = userRepository;

        }
        public IActionResult Login()
        {
            /*if(User.Identity!.IsAuthenticated)
            {
                return RedirectToAction("index","posts");
            }*/
            return View();
        }
         public async Task<IActionResult> Register(RegisterViewmodel model)
        {
            if(ModelState.IsValid)
            {
                var user= await _userRepository.users.FirstOrDefaultAsync(x => x.username == model.username || x.email == model.email);
                if(user == null)
                {
                      _userRepository.CreateUser(new User
                      {
                        username = model.username,
                        name=model.name,
                        email = model.email,
                        password=model.password

                      });
                      return RedirectToAction("login");
                }
                else
                {
                    ModelState.AddModelError("","");
                }
                
            }
            return View();
        }
        public async Task<ActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("login");

        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewmodel model)
        {
            var claims = User.Claims;
            var posts =_userRepository.users;
            if(ModelState.IsValid)
            {
                 var isuser=_userRepository.users.FirstOrDefault(x => x.email == model.email && x.password == model.password);
                 if(isuser != null)
                 {
                       var userClaims= new List<Claim>();
                       userClaims.Add(new Claim(ClaimTypes.NameIdentifier, isuser.userId.ToString()));
                       userClaims.Add(new Claim(ClaimTypes.Name, isuser.username ?? ""));
                       userClaims.Add(new Claim(ClaimTypes.GivenName, isuser.name ?? ""));
                       userClaims.Add(new Claim(ClaimTypes.UserData, isuser.Image ?? ""));
                       if(isuser.email=="qwer@gmail.com")
                       {
                          userClaims.Add(new Claim(ClaimTypes.Role, "admin"));
                       }
                       var claimsIdentity = new ClaimsIdentity(userClaims, CookieAuthenticationDefaults.AuthenticationScheme);
                       var authProperties= new AuthenticationProperties
                       {
                                IsPersistent=true
                       };
                       await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

                       await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                       new ClaimsPrincipal(claimsIdentity),
                       authProperties
                       );
                       return RedirectToAction("Index","Posts");
                 }
                  else
                  {
                     ModelState.AddModelError("","kullanıcı adı veya şifre yanlış");
                  }
            }
           
            return View();
        }
        public IActionResult Profile(string username)
        {
            if(string.IsNullOrEmpty(username))
            {
                return NotFound();
            }
            var user=_userRepository
                    .users
                    .Include(x => x.posts)
                    .Include(x=>x.comments)
                    .ThenInclude(x=>x.post)
                    .FirstOrDefault(x => x.username == username);

            if(user==null)
            {
                return NotFound();
            }
            return View(user);
        }


     }

}