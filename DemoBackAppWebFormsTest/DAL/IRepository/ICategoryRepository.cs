using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
namespace DemoBackAppWebFormsTest.DAL.IRepository
{
    public interface ICategoryRepository
    {
        List<Category> GetAll();
        Category GetById(int id);
        void Add(Category category);
        void Update(Category category);
        void Delete(int id);
    }
}
