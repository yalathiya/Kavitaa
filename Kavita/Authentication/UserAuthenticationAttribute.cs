using Kavita.BL;
using Kavita.Security;
using System;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace Kavita.Authentication
{
    /// <summary>
    /// Authenticates User by Id & Password
    /// </summary>
    public class UserAuthenticationAttribute : AuthorizationFilterAttribute
    {
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            // If request header has no credential for login
            if (actionContext.Request.Headers.Authorization == null)
            {
                actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Login Failed");
            }
            // If request consists credential for login
            else
            {
                try
                {
                    // It comes with request as parameter
                    string authToken = actionContext.Request.Headers.Authorization.Parameter;

                    // authToken = username:password
                    // authToken is base 64 encoded

                    // To convert string from the base64 encoding 
                    string decodedAuthToken = Encoding.UTF8.GetString(Convert.FromBase64String(authToken));

                    // To Decrypt password
                    AesAlgo aes = new AesAlgo();

                    // To extract username and password
                    string[] credential = decodedAuthToken.Split(':');
                    string username = credential[0];
                    string password = aes.Decrypt(credential[1]);

                    // If user credential are correct
                    if (BLLogin.Login(username, password))
                    {
                       // Login Success
                    }
                    // If user creadential are incorrect
                    else
                    {
                        // Returns unauthenticated user - " Login Failed " 
                        actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, "Incorrect Credential"); // Status Code 401
                    }

                }
                // If any exception occurs within the process, It returns  Internal Server Error with the exception
                catch (Exception exception)
                {
                    // Returns Internal servar error with the stack of exception 
                    actionContext.Response = actionContext.Request.CreateErrorResponse(HttpStatusCode.InternalServerError, exception); // Status Code 500
                }

            }

        }
    }
}