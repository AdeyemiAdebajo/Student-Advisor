using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentAdvisor.Models;
using StudentAdvisor.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container with authentication enforced
builder.Services.AddRazorPages(options =>
{
    // Require authentication for all pages
    options.Conventions.AuthorizeFolder("/");

    // Allow anonymous access to the login page
    options.Conventions.AllowAnonymousToPage("/Identity/Account/Login");
});

ServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));

builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseMySql(builder.Configuration.GetConnectionString("StudentAdvisorDb"), serverVersion)
    .LogTo(Console.WriteLine, LogLevel.Information)
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors()
);

builder.Services.AddDefaultIdentity<Register>(options => 
{ 
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbcontext>();

// Register UserManager & SignInManager for Custom User Model
builder.Services.AddScoped<UserManager<Register>>();
builder.Services.AddScoped<SignInManager<Register>>();

// Needed for session
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Session timeout (30 minutes)
    options.Cookie.HttpOnly = true; // Security
    options.Cookie.IsEssential = true; // Make sure session is available
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication(); // Ensure authentication middleware is applied
app.UseAuthorization();

app.MapRazorPages();

app.Run();
