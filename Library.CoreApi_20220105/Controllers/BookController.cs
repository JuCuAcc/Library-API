using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Library.CoreApi_20220105.Entities;
using Library.CoreApi_20220105.DAL.Interfaces;


namespace Library.CoreApi_20220105.Controllers
{
    [Route("api/Book")]
    //[Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        public IBookRepository _irepo;

        public BookController(IBookRepository repository)
        {
            _irepo = repository;
        }

        [HttpGet, Route("GetBooks")]
        public async Task<IActionResult> Get()
        {
            var book = await _irepo.Get();
            return Ok(book);
        }
        [HttpGet, Route("GetBooks/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var book = await _irepo.Get(id);
            if (book == null)
            {
                return Content("Cannot Find the Book");
            }
            return Ok(book);
        }

        [HttpGet, Route("SearchBook/{searchString}")]
        public IActionResult SearchByBookName(string searchString)
        {
            var books = _irepo.SearchBook(searchString);
            return Ok(books);
        }



        [HttpGet, Route("GetActiveBook")]
        public IActionResult GetActiveBook()
        {
            var books = _irepo.GetActiveBooks();
            return Ok(books);
        }

        [HttpGet, Route("GetInActiveBook")]
        public IActionResult GetInActiveBook()
        {
            var books = _irepo.GetInActiveBooks();
            return Ok(books);
        }


        [HttpPost, Route("InsertBook")]
        public async Task<IActionResult> Post(Book book)
        {
            await _irepo.Post(book);
            return Ok(book);
        
        }


        [HttpPut, Route("UpdateBook/{id}")]

        public async Task<IActionResult> Post(int id, Book book)
        {
            await _irepo.Put(id,book);
            return Ok(book);

        }

        [HttpDelete, Route("DeleteBooks/{id}")]

        public async Task<IActionResult> DeleteBooks(int id)
        {
            var book = await _irepo.Get(id);
            if (book == null)
            {
                return Content("The Book is not exists.");
            }
            await _irepo.Delete(id);
            return Ok(book);
        }


    }
}
