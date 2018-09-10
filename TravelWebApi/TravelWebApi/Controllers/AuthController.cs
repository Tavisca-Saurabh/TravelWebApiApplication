using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TravelWebApi.Auth;

namespace TravelWebApi.Controllers
{
    public class AuthController : ApiController
    {
        [Route("api/authenticate")]
        [HttpPost()]
        public IHttpActionResult Authenticate([FromBody] AuthBinding credentials)
        {
            if (credentials != null)
            {
                AuthProvider provider = new AuthProvider(credentials.UserName, credentials.Password);
                var userType = provider.Authenticate();
                if (userType.HasValue)
                {
                    User currentUser = new User();
                    currentUser.Id = Guid.NewGuid();
                    currentUser.IsAuthenticated = true;
                    currentUser.UserType = userType;
                    return Ok(currentUser);
                }
                return BadRequest("Invalid credentials");
            }
            return BadRequest("Please enter credentials");
        }


        // GET: api/Auth
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Auth/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Auth
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Auth/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Auth/5
        public void Delete(int id)
        {
        }
    }
}
