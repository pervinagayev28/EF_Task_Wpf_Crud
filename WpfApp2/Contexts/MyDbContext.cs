using ConsoleApp5.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp5.Contexts
{
    public class MyDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=DESKTOP-47DGCU6\\SQL;Initial Catalog=MyLibraryDb;User ID=MySql;Password=pervina9266_1;Connect Timeout=30;");
            base.OnConfiguring(optionsBuilder);
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }


        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Facultie> Faculties { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Lib> Libs{ get; set; }
        public DbSet<Press> Presses{ get; set; }
        public DbSet<S_Card> S_Cards{ get; set; }
        public DbSet<T_Card> T_Cards{ get; set; }
        public DbSet<Student> Students{ get; set; }
        public DbSet<Teacher> Teachers{ get; set; }
        public DbSet<Theme> Themes{ get; set; }



    }
}
