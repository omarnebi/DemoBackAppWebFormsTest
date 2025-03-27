using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBackAppWebFormsTest.BLL.IService
{
    internal interface IProductService
    {
        List<Product> GetAllProducts();
        Product GetProduct(int id);
        void CreateProduct(Product product);
        void UpdateProduct(Product product);
        void RemoveProduct(int id);
    }
}
