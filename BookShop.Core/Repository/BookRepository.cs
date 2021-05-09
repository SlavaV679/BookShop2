using BookShop.Core.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookShop.Core.Repository
{
    public class BookRepository : BookDbContext
    {
        public BookRepository(DbContextOptions options) : base()
        {

        }

        public Book GetBook()
        {
            var Db = new BookDbContext();
            return null;
        }
    }
}
