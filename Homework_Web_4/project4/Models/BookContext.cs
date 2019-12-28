﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace project4.Models
{
    public class BookContext : DbContext
    {
        public DbSet<Book> Books{ get; set; }
        public DbSet<Author> Authors { get; set; }

        public BookContext(DbContextOptions<BookContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
