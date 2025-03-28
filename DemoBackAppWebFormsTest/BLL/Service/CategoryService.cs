using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.DAL.IRepository;

namespace DemoBackAppWebFormsTest.BLL
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
        {
            _repository = repository;
        }

        public List<Category> GetAll()
        {
           return _repository.GetAll();
        }

        public Category GetById(int id) {

           return _repository.GetById(id);
        }

        public void Add(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name) && string.IsNullOrWhiteSpace(category.Description))
                throw new ArgumentException(" give the name and description of category ");

            _repository.Add(category);
        }

        public void Edit(Category category) { 
        
          _repository.Update(category);
        }

        public void Remove(int id) {

            _repository.Delete(id);
        } 
    }
}