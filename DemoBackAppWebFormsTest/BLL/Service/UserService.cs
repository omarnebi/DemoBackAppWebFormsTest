using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.DAL.IRepository;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace DemoBackAppWebFormsTest.BLL.Service
{
    public class UserService:IUserService
    {
        private readonly IUserRepository _repository;

        public UserService(IUserRepository repository)
        {
            _repository = repository;
        }

        public List<User> GetAll()
        {
            return _repository.GetAll();
        }

        public User GetById(int id)
        {
            var User = _repository.GetById(id);
            if (User == null)
            {
                throw new KeyNotFoundException($"the id of porduct {id} not  found");
            }
            return User;
        }

        public void Add(User User)
        {
            if (string.IsNullOrWhiteSpace(User.UserName) && string.IsNullOrWhiteSpace(User.Email))
                throw new ArgumentException(" give the name and email of User");

            if (User.Password.Length <= 5)
                throw new ArgumentException(" the length of password <6");

            _repository.Add(User);
        }

        public void Edit(User User)
        {
            var existingUser = _repository.GetById(User.Id);
            if (existingUser == null)
            {
                throw new KeyNotFoundException($"User not found with  curent id {User.Id}");
            }

            _repository.Update(User);
        }

        public void Remove(int id)
        {
            var User = _repository.GetById(id);
            if (User == null)
            {
                throw new KeyNotFoundException($"User not found with this id {id}.");
            }

            _repository.Delete(id);
        }
        public User Login(string username, string password)
        {
            var user = _repository.GetUserByName(username);
            if (user == null)
            {
                throw new KeyNotFoundException($"UserName {username} not found");
            }
            if((user.UserName==username)&&(user.Password == password))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }

}
