using Microsoft.EntityFrameworkCore;
// using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


using StudentAdvisor.Models;
using Microsoft.AspNetCore.Identity;


namespace StudentAdvisor.Data;

public class AppDbcontext : IdentityDbContext<Register>
{
     public AppDbcontext(DbContextOptions<AppDbcontext> options)
        : base(options) { }
        // public virtual DbSet<Register> Register { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        var admin= new IdentityRole("admin");
        admin.NormalizedName="admin";

        var client= new IdentityRole("client");
        client.NormalizedName="client";
        
        modelBuilder.Entity<IdentityRole>().HasData(admin,client);


        // modelBuilder.Entity<Register>().HasIndex(u => u.Email).IsUnique();
    }

}
