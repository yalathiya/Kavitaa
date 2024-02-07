using Kavita.Authentication;
using Kavita.BL;
using System.Web.Http;

namespace Kavita.Controllers
{
    /// <summary>
    /// It provides routing & functionality related to kavita  
    /// </summary>
    [RoutePrefix("api/kavita")]
    public class CLKavitaController : ApiController
    {
        /// <summary>
        /// This method finds kavita from the database by using kavitaId
        /// It collects details of kavita from the request url
        /// </summary>
        /// <param name="kavitaId"> KavitaId of Kavita </param>
        /// <returns> Object of kavita </returns>
        /// <summary>
        [HttpGet]
        [Route("get")]
        public IHttpActionResult GetKavita(int kavitaId)
        {
            BLKavita objBLKavita = new BLKavita();
            Kavita.Models.Kavita objKavita = objBLKavita.GetKavita(kavitaId);
            return Ok(objKavita);
        }

        /// <summary>
        /// This method adds kavita in database,
        /// It collects kavita details from the request body as object of kavita model
        /// </summary>
        /// <param name="objKavita"> Object of Kavita model </param>
        /// <returns> "Added" </returns>
        [HttpPost]
        [Route("Add")]
        [UserAuthentication]
        public IHttpActionResult AddKavita([FromBody] Kavita.Models.Kavita objKavita)
        {
            BLKavita objBLKavita = new BLKavita();
            objBLKavita.AddKavita(objKavita);

            return Ok("Added");
        }

        /// <summary>
        /// This method updates kavita in database,
        /// It collects kavita details from the request body as object of Kavita model
        /// </summary>
        /// <param name="objKavita"> Object of Kavita model </param>
        /// <returns> "Updated" </returns>
        [HttpPut]
        [Route("Update")]
        [UserAuthentication]
        public IHttpActionResult UpdateUser([FromBody] Kavita.Models.Kavita objKavita)
        {
            BLKavita objBLKavita = new BLKavita();
            objBLKavita.UpdateKavita(objKavita);

            return Ok("Updated");
        }

        /// <summary>
        /// This method deletes user from the database by using kavitaId
        /// It collects user details from the request url
        /// </summary>
        /// <param name="kavitaId"> KavitaId of specific kavita </param>
        /// <returns> "Deleted" </returns>
        [HttpDelete]
        [Route("delete")]
        [UserAuthentication]
        public IHttpActionResult DeleteUSer(int kavitaId)
        {
            BLKavita objBLKavita = new BLKavita();
            Kavita.Models.Kavita objKavita = objBLKavita.DeleteKavita(kavitaId);
            return Ok(" Deleted ");
        }
    }
}
