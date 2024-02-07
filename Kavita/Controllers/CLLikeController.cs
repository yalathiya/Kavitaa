using Kavita.Authentication;
using Kavita.BL;
using System.Web.Http;

namespace Kavita.Controllers
{
    public class CLLikeController : ApiController
    {
        /// <summary>
        /// To add like
        /// </summary>
        /// <param name="kavitaId"></param>
        /// <returns></returns>
        [HttpPost]
        [UserAuthentication]
        [Route("api/like")]
        public IHttpActionResult Like(int kavitaId)
        {
            BLLike likeManager = new BLLike();
            likeManager.Like(kavitaId);

            return Ok("Liked");
        }

        /// <summary>
        /// To unlike
        /// </summary>
        /// <param name="kavitaId"></param>
        /// <returns></returns>
        [HttpPost]
        [UserAuthentication]
        [Route("api/unlike")]
        public IHttpActionResult Unike(int kavitaId)
        {
            BLLike likeManager = new BLLike();
            likeManager.Unlike(kavitaId);

            return Ok("Unliked");
        }
    }
}
