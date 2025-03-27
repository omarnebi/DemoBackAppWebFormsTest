using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBackAppWebFormsTest.DAL
{
    using DemoBackAppWebFormsTest.BLL.IService;
    using DemoBackAppWebFormsTest.DAL.IRepository;
    using DemoBackAppWebFormsTest.DAL.Models;
    using System.Collections.Generic;
    using System.Linq;

    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Category> GetCategories() => _context.Categories.ToList();

        public Category GetCategoryById(int id) => _context.Categories.Find(id);

        public void AddCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category != null)
            {
                _context.Categories.Remove(category);
                _context.SaveChanges();
            }
        }
    }

}