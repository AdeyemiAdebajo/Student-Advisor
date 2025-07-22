using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using StudentAdvisor.Models;
using StudentAdvisor.Data;
using Microsoft.Extensions.DependencyInjection;
using DotNetEnv;

var builder = WebApplication.CreateBuilder(args);
DotNetEnv.Env.Load();

// Add services to the container with authentication enforced
// builder.Services.AddRazorPages();
builder.Services.AddHttpClient(); // ✅ Add this to enable IHttpClientFactory

builder.Services.AddRazorPages(options =>
{
    // Require authentication for all pages
    options.Conventions.AuthorizeFolder("/");

    // Allow anonymous access to the login page
    options.Conventions.AllowAnonymousToPage("/Identity/Account/Login");
});


// builder.Services.AddDbContext<AppDbcontext2>(options =>
//     options.UseSqlServer(builder.Configuration.GetConnectionString("StudentAdvisorDb") ?? throw new InvalidOperationException("Connection string 'AppDbcontext2' not found.")));


ServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));
string connStr = Environment.GetEnvironmentVariable("StudentAdvisor_Dbserver");

// builder.Services.AddDbContext<AppDbcontext>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("StudentAdvisorDb"), serverVersion)
//     .LogTo(Console.WriteLine, LogLevel.Information)
//     .EnableSensitiveDataLogging()
//     .EnableDetailedErrors()
// );
builder.Services.AddDbContext<AppDbcontext>(options =>
    options.UseMySql(connStr, serverVersion)
           .LogTo(Console.WriteLine, LogLevel.Information)
           //Use the following line to enable sensitive data logging
);
// builder.Services.AddDbContext<AppDbcontext2>(options =>
//     options.UseMySql(builder.Configuration.GetConnectionString("StudentAdvisorDb"), serverVersion)
//     .LogTo(Console.WriteLine, LogLevel.Information)
//     .EnableSensitiveDataLogging()
//     .EnableDetailedErrors()
// );
builder.Services.AddDbContext<AppDbcontext2>(options =>
    options.UseMySql(connStr, serverVersion)
           .LogTo(Console.WriteLine, LogLevel.Information)
           //Use the following line to enable sensitive data logging
);

builder.Services.AddDefaultIdentity<Register>(options =>
{
    options.SignIn.RequireConfirmedAccount = false;
})
.AddRoles<IdentityRole>()
.AddEntityFrameworkStores<AppDbcontext>();



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


// Register UserManager & SignInManager for Custom User Model
// builder.Services.AddScoped<UserManager<Register>>();
// builder.Services.AddScoped<SignInManager<Register>>();