using Microsoft.EntityFrameworkCore;

using StudentAdvisor.Models;


namespace StudentAdvisor.Data;

public class AppDbcontext : DbContext
{
     public AppDbcontext(DbContextOptions<AppDbcontext> options)
        : base(options) { }
        public virtual DbSet<Register> Register { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Register>().HasIndex(u => u.Email).IsUnique();
    }

}
