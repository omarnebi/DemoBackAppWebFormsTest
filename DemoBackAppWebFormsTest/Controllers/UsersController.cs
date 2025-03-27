using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DemoBackAppWebFormsTest.Controllers
{
    public class UsersController : ApiController
    {
        [HttpGet]
        [Route("api/users")]
        public IHttpActionResult GetUsers()
        {
            var users = new List<string> { "Omar", "Nabi", "Alice", "Bob" };
            return Ok(users);
        }
    }
}
