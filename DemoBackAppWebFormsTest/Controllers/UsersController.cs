using DemoBackAppWebFormsTest.BLL.IService;
using DemoBackAppWebFormsTest.BLL.Service;
using DemoBackAppWebFormsTest.BO;
using DemoBackAppWebFormsTest.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace DemoBackAppWebFormsTest.Controllers
{
    public class UsersController : ApiController
    {
        private readonly IUserService _UserService;

        public UsersController(IUserService UserService)
        {
            _UserService = UserService;
        }

        /// <summary>
        /// Get all Users.
        /// </summary>
        [HttpGet]
        [Route("api/Users")]
        public IHttpActionResult GetAllUsers()
        {
            try
            {
                List<User> AllUsers = _UserService.GetAll();
                return Ok(AllUsers);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Get User by ID.
        /// </summary>
        [HttpGet]
        [Route("api/Users/{id}")]
        public IHttpActionResult GetUserById(int id)
        {
            try
            {
                User CurentUser = _UserService.GetById(id);
                return Ok(CurentUser);
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Create User.
        /// </summary>
        [HttpPost]
        [Route("api/Users")]
        public IHttpActionResult AddUser([FromBody] User User)
        {
            try
            {
                if (User == null)
                    return BadRequest("User data is required");

                _UserService.Add(User);
                return Ok(" new User created");
            }
            catch (ArgumentException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// Edit curent User.
        /// </summary>
        [HttpPut]
        [Route("api/Users/{id}")]
        public IHttpActionResult EditUser(int id, [FromBody] User User)
        {
            try
            {
                if (User == null)
                    return BadRequest("User attributes is required");

                if (id != User.Id)
                    return BadRequest("User is not  found");

                _UserService.Edit(User);
                return Ok("User updated with new data");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        /// <summary>
        /// remove  object User by Id.
        /// </summary>
        [HttpDelete]
        [Route("api/Users/{id}")]
        public IHttpActionResult RemoveUserById(int id)
        {
            try
            {
                _UserService.Remove(id);
                return Ok("User by id removed");
            }
            catch (KeyNotFoundException ex)
            {
                return NotFound();
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }


        [HttpPost]
        [Route("api/login")]
        public IHttpActionResult Login([FromBody] UserLoginDTO model)
        {
            var user = _UserService.Login(model.UserName, model.Password);
            if (user != null)
            {
                var cookie = new HttpCookie("AuthCookie")
                {
                    Value = user.UserName,
                    Expires = DateTime.Now.AddMinutes(60),
                    Secure = true,
                    HttpOnly = true,
                    SameSite=SameSiteMode.Strict,
                };

                HttpContext.Current.Response.Cookies.Add(cookie);

                return Ok(new { message = "Login successful" });
            }
            else
            {
                return Unauthorized();
            }
        }

    }
}

