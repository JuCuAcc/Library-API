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
    public class CategoryRepository:IRepository<Category>
    {
        readonly ApplicationDbContext _context;
        public CategoryRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> Get()
        {
            return await _context.Categories.ToListAsync();
        }

        public async Task<Category> Get(int id)
        {
            var category = await _context.Categories.FindAsync(id);
            return category;
        }

        public async Task<object> Post(Category entity)
        {
            if (_context.Categories.Any(c => c.CategoryName == entity.CategoryName))
            {
                return null;
            }

            _context.Categories.Add(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Put(int id, Category entity)
        {
            var category = _context.Categories.Find(id);
            category.CategoryName = entity.CategoryName;
            category.IsActive = entity.IsActive;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<object> Delete(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                await _context.SaveChangesAsync();
                return category;
            }
            return null;
        }
    }
}
