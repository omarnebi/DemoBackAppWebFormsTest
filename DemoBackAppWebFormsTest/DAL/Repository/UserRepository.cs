using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBackAppWebFormsTest.DAL.Repository
{
    public class UserRepository:IUserRepository
    {
        private readonly MyDbContext _context;

        public UserRepository(MyDbContext context)
        {
            _context = context;
        }

        //Get All Pordcuts
        public List<User> GetAll()
        {

            return _context.Users.ToList();
        }
        // Get by id User 
        public User GetById(int id)
        {
            return _context.Users.Find(id);
        }

        // Add new  User
        public void Add(User User)
        {
            _context.Users.Add(User);
            _context.SaveChanges();
        }

        // edit User
        public void Update(User User)
        {
            _context.Entry(User).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }

        //delete by id 
        public void Delete(int id)
        {
            var User = _context.Users.Find(id);
            if (User != null)
            {
                _context.Users.Remove(User);
                _context.SaveChanges();
            }
        }
        public User GetUserByName( string username)
        {

            return _context.Users.FirstOrDefault(u => u.UserName == username);

        }
    }
}
