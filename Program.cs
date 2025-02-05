using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
// using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

using StudentAdvisor.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
ServerVersion serverVersion = new MariaDbServerVersion(new Version(10, 4, 32));


builder.Services.AddDbContext<AppDbcontext>(options =>
 options.UseMySql(builder.Configuration.GetConnectionString("StudentAdvisorDb"), serverVersion)
 .LogTo(Console.WriteLine, LogLevel.Information)
 .EnableSensitiveDataLogging()
 .EnableDetailedErrors()
);
// Add Identity services
// builder.Services.AddIdentity<IdentityUser, IdentityRole>(options =>
// {
//     options.SignIn.RequireConfirmedAccount = true;
// })
// .AddEntityFrameworkStores<AppDbcontext>()
// .AddDefaultTokenProviders(); 

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
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseSession();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
