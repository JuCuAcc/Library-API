using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.EntityFrameworkCore;
using Library.CoreApi_20220105.Entities;

namespace Library.CoreApi_20220105.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        #region DbSet
        public DbSet<Category> Categories {get; set;}
        public DbSet<Author> Authors {get; set;}
        public DbSet<Publisher> Publishers {get; set;}
        public DbSet<Book> Books {get; set;}

        #endregion

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Novel", IsActive = true },
                new Category { CategoryId = 2, CategoryName = "History", IsActive = true },
                new Category { CategoryId = 3, CategoryName = "Jokes", IsActive = true }
            );

            builder.Entity<Author>().HasData(
                new Author { AuthorId = 1, AuthorName = "Foysal", DoB = DateTime.Parse("01/01/1980"), ContactNo = "01947193694", Email = "foysal@mail.com", IsActive = true },
                new Author { AuthorId = 2, AuthorName = "Wahid", DoB = DateTime.Parse("01/01/1987"), ContactNo = "01747193694", Email = "wahid@mail.com", IsActive = true },
                new Author { AuthorId = 3, AuthorName = "Rasel", DoB = DateTime.Parse("01/01/1995"), ContactNo = "01547193694", Email = "rasel@mail.com", IsActive = true }
            );

            builder.Entity<Author>().Property(a => a.IsActive).HasDefaultValue(true);
            builder.Entity<Author>().Property(a => a.DoB).IsRequired();
            builder.Entity<Category>().Property(c => c.IsActive).HasDefaultValue(true);
            builder.Entity<Book>().Property(b => b.IsActive).HasDefaultValue(true);
            builder.Entity<Publisher>().Property(p => p.IsActive).HasDefaultValue(true);

        }
    }
}
