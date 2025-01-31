using Microsoft.EntityFrameworkCore;

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


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();
