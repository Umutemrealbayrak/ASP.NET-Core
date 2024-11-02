using BlogApp.Data.Abstract;
using BlogApp.Data.Concrete;
using BlogApp.Data.Concrete.EfCore;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<BlogContext>(options =>{
    var config=builder.Configuration;
    var connectionstring = config.GetConnectionString("sql_connection"); 
    options.UseSqlite(connectionstring);
});


builder.Services.AddScoped<IPostRepository, EfPostRepository>();
builder.Services.AddScoped<ITagRepository, EfTagRepository>();
builder.Services.AddScoped<ICommentRepository, EfCommentRepository>();
builder.Services.AddScoped<IUserRepository, EfUserRepository>();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).AddCookie(options=>options.LoginPath="/Users/Login");
var app = builder.Build();

app.UseStaticFiles();

app.UseAuthentication();
app.UseAuthorization();

SeedData.TestVerileriniDoldur(app); 

app.MapControllerRoute(
    name: "post_details",
    pattern:"blog/details/{url}",
    defaults: new { controller = "Posts",Action="Details"}
);
app.MapControllerRoute(
    name: "tag_details",
    pattern:"blog/tag/{tag}",
    defaults: new { controller = "Posts",Action="Index"}
);
app.MapControllerRoute(
    name: "user_profile",
    pattern:"profile/{username}",
    defaults: new { controller = "Users",Action="Profile"}
);


app.MapControllerRoute(
    name: "default",
    pattern:"{controller=Posts}/{action=Index}/{id?}"
);

app.Run();
