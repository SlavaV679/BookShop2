using Microsoft.EntityFrameworkCore;
using System;

namespace FirstApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using (AppContext context = new AppContext())
            {
                context.Users.Add(new User() { Name = "Vitalik", Age = 25 });

                context.SaveChanges();
            }
        }
    }

    class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
    }

    class AppContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=TestDB; Trusted_Connection=true");
        }
    }
}
