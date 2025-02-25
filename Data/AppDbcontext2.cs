using System;
using Microsoft.EntityFrameworkCore;
using StudentAdvisor.Models;

namespace StudentAdvisor.Data;

public class AppDbcontext2 : DbContext
{
        public AppDbcontext2(DbContextOptions<AppDbcontext2> options)
           : base(options) { }

        public virtual DbSet<Student>? Students { get; set; }
        public virtual DbSet<Study>? Studies{ get; set; }
          protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        
        modelBuilder.Entity<Student>().ToTable("Student");
        modelBuilder.Entity<Study>().ToTable("Study");
    }
}
