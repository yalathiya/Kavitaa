using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Kavita.Authentication
{
    public static class CurrentUser
    {
        // returns current username from the request header authorization
        public static string GetUsername()
        {
            if (HttpContext.Current == null)
            {
                throw new Exception("No cuurent user found");
            }
            return ((ClaimsIdentity)HttpContext.Current.User.Identity).Claims.Where(c => c.Type == "username").Select(c => c.Value).FirstOrDefault();
        }
    }
}