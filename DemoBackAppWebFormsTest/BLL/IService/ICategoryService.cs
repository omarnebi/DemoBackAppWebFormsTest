using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBackAppWebFormsTest.BLL.IService
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories();
        Category GetCategory(int id);
        void CreateCategory(Category category);
        void UpdateCategory(Category category);
        void RemoveCategory(int id);
    }
}
