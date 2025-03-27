using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBackAppWebFormsTest.DAL
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _context;

        public ProductRepository(MyDbContext context)
        {
            _context = context;
        }

        public List<Product> GetProducts() => _context.Products.Include("Category").ToList();

        public Product GetProductById(int id) => _context.Products.Find(id);

        public void AddProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        public void DeleteProduct(int id)
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