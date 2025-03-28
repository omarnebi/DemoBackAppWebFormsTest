using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL.Models;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;


namespace DemoBackAppWebFormsTest.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        //Get All Pordcuts
        public List<Product> GetAll() 
        {
           
            return _context.Products.ToList();
        }
        // Get by id Product 
        public Product GetById(int id) 
        { 
          return _context.Products.Find(id);
        } 

        // Add new  Product
        public void Add(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        // edit product
        public void Update(Product product)
        {
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        //delete by id 
        public void Delete(int id)
        {
            var product = _context.Products.Find(id);
            if (product != null)
            {
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
        }
    }
}