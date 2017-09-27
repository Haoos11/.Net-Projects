using Jose;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Cors;

namespace Authentication_Server.Controllers
{
    public class User
    {
        public string Name;
        public string Password;

        public User(string name, string pass)
        {
            this.Name = name;
            this.Password = pass;
        }
    }

    public class LogedIn
    {
        public string loggedInAs;
        public DateTime issuedAt;
        public string username;
        public int securityLevel;

        public LogedIn()
        {
        }

        public LogedIn(string autorizationClass, DateTime date, string user, int securityLevel)
        {
            this.loggedInAs = autorizationClass;
            this.issuedAt = date;
            this.username = user;
            this.securityLevel = securityLevel;
        }
    }

    public class AuthenticationController : ApiController
    {
        User testUser = new User("vasile", "pass");
        private static readonly byte[] secretKey = new byte[] { 10, 11, 12 };

        [Route("api/Authentication/Authenticate")]
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "POST")]
        public IHttpActionResult Authenticate([FromBody]User user)
        {
            if (user.Name == testUser.Name && user.Password == testUser.Password)
            {
                DateTime actualDate = DateTime.Now.ToLocalTime();
                var obj = new LogedIn("user", actualDate, user.Name, 1);
                
                string token = Jose.JWT.Encode(obj, secretKey, JwsAlgorithm.HS256);

                HttpResponseMessage OkMessage = new HttpResponseMessage(HttpStatusCode.OK);
                //Body
                OkMessage = Request.CreateResponse(HttpStatusCode.OK, token);

                //Header
                OkMessage.Headers.Add("Authorized", "Access permited!");
                OkMessage.Headers.Add("Algorithm", "HS256");
                                
                return ResponseMessage(OkMessage);
            }
            else
            {
                string err = "INCORECT";
                HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unauthorized);
                response = Request.CreateResponse(HttpStatusCode.OK, err);
                response.Headers.Add("Unauthorized", "No Access!");
                return ResponseMessage(response);
            }
        }

        [Route("api/Authentication/Authorize")]
        [HttpPost]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public IHttpActionResult Authorize()
        {
            //toate headerele
            var x = Request.Headers;

            //headerul cu tokenul
            string token = x.GetValues("token").First();

            //decodarea si afisarea in clar a informatiilor
            LogedIn tokenDecodat = new LogedIn();
            tokenDecodat = JWT.Decode<LogedIn>(token, secretKey, JwsAlgorithm.HS256);
      
            HttpResponseMessage OkMessage = new HttpResponseMessage(HttpStatusCode.OK);
            //Body
            OkMessage = Request.CreateResponse(HttpStatusCode.OK, tokenDecodat);

            return ResponseMessage(OkMessage);
        }
    }
}
