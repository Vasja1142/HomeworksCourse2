using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LR_3
{

    public class ApplicationContext : DbContext
    {
        internal DbSet<Person> Persons { get; set; }
        internal DbSet<Department> Departments { get; set; } // Добавьте DbSet для Department

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=1142");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().ToTable("table_gordeev");
            modelBuilder.Entity<Person>().Property(u => u.Id).ValueGeneratedOnAdd();

            modelBuilder.Entity<Department>().ToTable("departments"); // Настройте таблицу для Department
            modelBuilder.Entity<Department>().Property(d => d.Id).ValueGeneratedOnAdd();

            // Определение отношения между Person и Department
            modelBuilder.Entity<Person>()
                .HasOne(p => p.Department)
                .WithMany(d => d.Persons)
                .HasForeignKey(p => p.DepartmentId);


        }
    }
}
