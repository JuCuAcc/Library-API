using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Library.CoreApi_20220105.Entities;

namespace Library.CoreApi_20220105.DAL.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {
        IEnumerable<Book> GetBooksByAuthor(int authorId);
        IEnumerable<Book> GetBooksByPublisher(int publisherId);
        IEnumerable<Book> GetBooksByCategory(int categoryId);
        IEnumerable<Book> SearchBook(string searchString);
        IEnumerable<Book> GetActiveBooks();
        IEnumerable<Book> GetInActiveBooks();

    }
}
