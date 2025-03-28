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

        public List<Product> GetAll()
        {
            return _repository.GetAll();
        }

        public Product GetById(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"the id of porduct {id} not  found");
            }
            return product;
        }

        public void Add(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name))
                throw new ArgumentException(" give the name of product");

            if (product.Price <= 0)
                throw new ArgumentException(" the curent Price <=0 - Price should be >0");

            _repository.Add(product);
        }

        public void Edit(Product product)
        {
            var existingProduct = _repository.GetById(product.Id);
            if (existingProduct == null)
            {
                throw new KeyNotFoundException($"product not found with  curent id {product.Id}");
            }

            _repository.Update(product);
        }

        public void Remove(int id)
        {
            var product = _repository.GetById(id);
            if (product == null)
            {
                throw new KeyNotFoundException($"product not found with this id {id}.");
            }

            _repository.Delete(id);
        }
    }
}