using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBackAppWebFormsTest.BLL.Service
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _repository;

        public ProductService(IProductRepository repository)
        {
            _repository = repository;
        }

        public List<Product> GetAllProducts()
        {
            return _repository.GetProducts();
        }

        public Product GetProduct(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"No product found with ID {id}.");
            }
            return product;
        }

        public void CreateProduct(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException("Product name is required.");

            if (product.Price <= 0)
                throw new ArgumentException("Price must be greater than zero.");

            _repository.AddProduct(product);
        }

        public void UpdateProduct(Product product)
        {
            var existingProduct = _repository.GetProductById(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"No product found with ID {product.Id}.");
            }

            _repository.UpdateProduct(product);
        }

        public void RemoveProduct(int id)
        {
            var product = _repository.GetProductById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"No product found with ID {id}.");
            }

            _repository.DeleteProduct(id);
        }
    }
}