using Kavita.Authentication;
using Kavita.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kavita.Controllers
{
    /// <summary>
    /// It provides login & logout functionality
    /// </summary>
    public class CLLoginController : ApiController
    {
        /// <summary>
        /// To user login
        /// </summary>
        /// <param name="credential"> object which contains username and password </param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/login")]
        [UserAuthentication]
        public IHttpActionResult Login()
        {
            return Ok("Logged In");
        }

        /// <summary>
        /// For Logout 
        /// </summary>
        /// <returns></returns>
        //[HttpPost]
        //[Route("api/logout")]
        //public IHttpActionResult Logout()
        //{
        //    BLLogin.Logout();
        //    return Ok("Logout");
        //}
    }
}
