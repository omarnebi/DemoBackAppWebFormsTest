using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBackAppWebFormsTest.BLL.IService
{
    public interface IUserService
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User User);
        void Edit(User User);
        void Remove(int id);
        User Login(string username, string password);
    }
}
