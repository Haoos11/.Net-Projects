using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;

namespace Authentication_Server.Controllers
{
    public class User
    {
        public string Name;
        public string passWord;

        public User(string name, string pass)
        {
            this.Name = name;
            this.passWord = pass;
        }
   }

    public class AuthenticationController : ApiController
    {
        User testUser = new User("vasile", "pass");
        

        [HttpPost]
        public IHttpActionResult Authenticate([FromBody]User user)
        {
            if (user.Name == testUser.Name && user.passWord == testUser.passWord)
            {
                var OkResponse = new HttpResponseMessage(HttpStatusCode.OK);
                OkResponse.Headers.Add("Authorized", "Ai nimerit credentialele!");
                return ResponseMessage(OkResponse);

            }

            var response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
            response.Headers.Add("Unauthorized","PAAAA!!!");
            

            return ResponseMessage(response);
        }

    }
}
