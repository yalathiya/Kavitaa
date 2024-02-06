using Kavita.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Kavita.Controllers
{
    public class CLLikeController : ApiController
    {
        /// <summary>
        /// To add like
        /// </summary>
        /// <param name="username"></param>
        /// <param name="kavitaId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/like/{kavitaId}/{username}")]
        public IHttpActionResult Like(string username, int kavitaId)
        {
            BLLike likeManager = new BLLike();
            likeManager.Like(username, kavitaId);

            return Ok("Liked");
        }

        /// <summary>
        /// To unlike
        /// </summary>
        /// <param name="username"></param>
        /// <param name="kavitaId"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("api/unlike/{kavitaId}/{username}")]
        public IHttpActionResult Unike(string username, int kavitaId)
        {
            BLLike likeManager = new BLLike();
            likeManager.Unlike(username, kavitaId);

            return Ok("Unliked");
        }
    }
}
