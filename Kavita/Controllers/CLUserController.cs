using Kavita.BL;
using Kavita.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace Kavita.Controllers
{
    /// <summary>
    /// It provides routing and functionalities for users
    /// </summary>
    [RoutePrefix("api/users")]
    public class CLUserController : ApiController
    {
        /// <summary>
        /// This method finds user from the database by using username
        /// It collects user details from the request url
        /// </summary>
        /// <param name="username"> Username of the user </param>
        /// <returns> Object of user </returns>
        [HttpGet]
        [Route("get/{username}")]
        public IHttpActionResult GetUser(string username)
        {
            BLUser objBLuser = new BLUser();
            Users objUsers = objBLuser.GetUser(username);
            return Ok(objUsers);
        }

        /// <summary>
        /// This method adds user in database,
        /// It collects user details from the request body as object of Users model
        /// </summary>
        /// <param name="objUsers"> Object of Users model </param>
        /// <returns> "Added" </returns>
        [HttpPost]
        [Route("Add")]
        public IHttpActionResult AddUser([FromBody] Users objUsers)
        {
            BLUser objBLuser = new BLUser();
            objBLuser.AddUser(objUsers);

            return Ok( "Added" );
        }

        /// <summary>
        /// This method updates user in database,
        /// It collects user details from the request body as object of Users model
        /// </summary>
        /// <param name="objUsers"> Object of Users model </param>
        /// <returns> "Updated" </returns>
        [HttpPatch]
        [Route("Update")]
        public IHttpActionResult UpdateUser([FromBody] Users objUsers)
        {
            BLUser objBLuser = new BLUser();
            objBLuser.UpdateUser(objUsers);

            return Ok("Updated");
        }

        /// <summary>
        /// This method deletes user from the database by using username
        /// It collects user details from the request url
        /// </summary>
        /// <param name="username"> Username of the user </param>
        /// <returns> "Deleted" </returns>
        [HttpGet]
        [Route("delete/{username}")]
        public IHttpActionResult DeleteUSer(string username)
        {
            BLUser objBLuser = new BLUser();
            Users objUsers = objBLuser.DeleteUser(username);
            return Ok("Deleted");
        }

    }
}
