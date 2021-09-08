using Microsoft.EntityFrameworkCore;
using System;

namespace ClassLibrary1
{
    public class Class1 : DbContext
    {
        public Class1()
        {

        }

        public DbSet<Test> Test { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=abedre;Initial Catalog=DTSolutionTest;Persist Security Info=True;User ID=sa;Password=Sql@007;").EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class Test
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
