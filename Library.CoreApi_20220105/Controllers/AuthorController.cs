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
    //[Route("api/[controller]")]
    [Route("api/Author")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        IRepository<Author> _authorRepo;

        public AuthorController(IRepository<Author> repository)
        {
            _authorRepo = repository;
        }

        [HttpGet, Route("GetAuthors")]
        public async Task<IActionResult> Get()
        {
            var author = await _authorRepo.Get();
            return Ok(author);
        }
        [HttpGet, Route("GetAuthor/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var author = await _authorRepo.Get(id);
            return Ok(author);
        }
        [HttpPost, Route("InsertAuthor")]
        public async Task<IActionResult> Post(Author author)
        {
            var data = await _authorRepo.Post(author);

            if (data != null)
            {
                return Ok(author);

            }
            return Content("This Author Already Exists!");
        }


        [HttpPut, Route("UpdateAuthor/{id}")]
        public async Task<IActionResult> Put(Author author, int id)
        {
            var data = await _authorRepo.Put(id, author);
            return Ok(data);
        }

        [HttpDelete, Route("DeleteAuthor/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var data = await _authorRepo.Delete(id);
            return Ok(data);

        }
    }
}
