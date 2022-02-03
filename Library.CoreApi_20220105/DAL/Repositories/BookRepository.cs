using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Library.CoreApi_20220105.DAL.Interfaces;
using Library.CoreApi_20220105.Entities;
using Library.CoreApi_20220105.Data;
using Microsoft.EntityFrameworkCore;

namespace Library.CoreApi_20220105.DAL.Repositories
{
    public class BookRepository : IBookRepository
    {
        private ApplicationDbContext _db;

        public BookRepository(ApplicationDbContext context)
        {
            _db = context;
        }
        public async Task<object> Delete(int id)
        {
            var book = await _db.Books.FindAsync(id);
            _db.Books.Remove(book);
            _db.SaveChanges();
            return book;
        }

        public async Task<IEnumerable<Book>> Get()
        {
            return await _db.Books.ToListAsync();
        }

        public async Task<Book> Get(int id)
        {
            var book = await _db.Books.FindAsync(id);
            return book;
        }

        public IEnumerable<Book> GetActiveBooks()
        {
            var book = from b in _db.Books
                       where b.IsActive == true
                       select b;
            return book;
        }
        public IEnumerable<Book> GetInActiveBooks()
        {
            var book = from b in _db.Books
                       where b.IsActive == false
                       select b;
            return book;
        }

        public IEnumerable<Book> SearchBook(string searchString)
        {
            var books = from b in _db.Books
                        where b.BookName.ToLower().Contains(searchString.ToLower())
                        select b;
            return books.ToList();
        }

        public IEnumerable<Book> GetBooksByAuthor(int authorId)
        {
            var books = from b in _db.Books
                        where b.AuthorId == authorId
                        select b;
            return books.ToList();
        }

        public IEnumerable<Book> GetBooksByCategory(int categoryId)
        {
            var books = from b in _db.Books
                        where b.CategoryId == categoryId
                        select b;
            return books.ToList();
        }

        public IEnumerable<Book> GetBooksByPublisher(int publisherId)
        {
            var books = from b in _db.Books
                        where b.PublisherId == publisherId
                        select b;
            return books.ToList();
        }



        public async Task<object> Post(Book entity)
        {
            _db.Books.Add(entity);
            await _db.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(Book entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            await _db.SaveChangesAsync();
            return entity;
        }
        public async Task<object> Put(int id, Book entity)
        {
            var book = _db.Books.Find(id);
            book.BookName = entity.BookName;

            book.CategoryId = entity.CategoryId;
            book.PublisherId = entity.PublisherId;
            book.AuthorId = entity.AuthorId;

            book.Description = entity.Description;
            book.Edition = entity.Edition;
            book.Price = entity.Price;
            book.IsActive = entity.IsActive;


            await _db.SaveChangesAsync();
            return entity;
        }


    }
}
