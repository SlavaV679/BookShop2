using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
/*
// https://www.c-sharpcorner.com/article/code-first-approach-in-asp-net-core-mvc-with-ef-core-migration/#:~:text=Code%20First%20Approach%20In%20ASP.NET%20Core%20MVC%20With%20EF%20Core%20Migration,-Mukesh%20Kumar&text=Code%20First%20is%20a%20technique,NET%20Code.
*/
namespace BookShop.Core.Context
{
    public class BookDbContext : DbContext
    {
        public DbSet<Book> Books { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=Books; Trusted_Connection=true");
        }
    }   
}
