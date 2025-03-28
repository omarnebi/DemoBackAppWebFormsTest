using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBackAppWebFormsTest.DAL.IRepository
{
    public interface IUserRepository
    {
        List<User> GetAll();
        User GetById(int id);
        void Add(User User);
        void Update(User User);
        void Delete(int id);
        User GetUserByName(string username);
    }
}
