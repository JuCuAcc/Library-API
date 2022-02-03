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
    public class AuthorRepository : IRepository<Author>
    {
        readonly ApplicationDbContext _context;
        public AuthorRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<object> Delete(int id)
        {
            var author = _context.Authors.Find(id);
            _context.Authors.Remove(author);
            await _context.SaveChangesAsync();
            return author;
        }

        public async Task<IEnumerable<Author>> Get()
        {
            return await _context.Authors.ToListAsync();
        }

        public async Task<Author> Get(int id)
        {
            return await _context.Authors.FindAsync(id);

        }

        public async Task<object> Post(Author entity)
        {
            _context.Authors.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Author entity)
        {
            var author = _context.Authors.Find(id);
            author.AuthorName = entity.AuthorName;
            author.DoB = entity.DoB;
            author.ContactNo = entity.ContactNo;
            author.Email = entity.Email;
            author.IsActive = entity.IsActive;

            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
