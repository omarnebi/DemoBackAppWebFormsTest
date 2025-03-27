using DemoBackAppWebFormsTest.DAL.Models;
using DemoBackAppWebFormsTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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

        public List<Category> GetAllCategories() => _repository.GetCategories();

        public Category GetCategory(int id) => _repository.GetCategoryById(id);

        public void CreateCategory(Category category)
        {
            if (string.IsNullOrWhiteSpace(category.Name))
                throw new ArgumentException("give the name of category.");

            _repository.AddCategory(category);
        }

        public void UpdateCategory(Category category) => _repository.UpdateCategory(category);

        public void RemoveCategory(int id) => _repository.DeleteCategory(id);
    }
}