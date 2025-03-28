using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL.Models;
using System.Collections.Generic;
using System.Linq;
namespace DemoBackAppWebFormsTest.DAL
{


    public class CategoryRepository : ICategoryRepository
    {
        private readonly MyDbContext _context;

        public CategoryRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Category> GetAll()
        {
          return  _context.Categories.ToList();
        }

        public Category GetById(int id) {

           return _context.Categories.Find(id);

        }
        public void Add(Category category)
        {
           
            _context.Categories.Add(category);
            _context.SaveChanges();
        }

        public void Update(Category category)
        {

            _context.Entry(category).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void Delete(int id)
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