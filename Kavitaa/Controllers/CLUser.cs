using Microsoft.AspNetCore.Mvc;
using Kavitaa.BL;
using Kavitaa.Models;

namespace Kavita.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class CLUserController : ControllerBase
    {
        private readonly BLUser _objBLuser;

        public CLUserController()
        {
            _objBLuser = new BLUser();
        }

        [HttpGet("get/{username}")]
        public IActionResult GetUser(string username)
        {
            Users objUsers = _objBLuser.GetUser(username);
            if (objUsers == null)
            {
                return NotFound();
            }

            return Ok(objUsers);
        }

        [HttpPost("add")]
        public IActionResult AddUser([FromBody] Users objUsers)
        {
            _objBLuser.AddUser(objUsers);
            return Ok("Added");
        }

        [HttpPatch("update")]
        public IActionResult UpdateUser([FromBody] Users objUsers)
        {
            _objBLuser.UpdateUser(objUsers);
            return Ok("Updated");
        }

        [HttpGet("delete/{username}")]
        public IActionResult DeleteUser(string username)
        {
            Users objUsers = _objBLuser.DeleteUser(username);
            if (objUsers == null)
            {
                return NotFound();
            }

            return Ok("Deleted");
        }
    }
}
