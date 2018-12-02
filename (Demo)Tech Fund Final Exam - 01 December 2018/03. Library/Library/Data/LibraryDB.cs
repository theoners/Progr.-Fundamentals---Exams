using Library.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Library.Data
{
    public class LibraryDB : DbContext
    {
        public DbSet<Book> Books { get; set; }

        public const string ConnectionString = @"Server=.\SQLEXPRESS;Database=LibraryDB;Trusted_Connection=True;";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConnectionString);
        }
    }
}
