using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kavitaa.Models
{
    /// <summary>
    /// This class represents model of users.
    /// </summary>
    public class Users
    {
        public ObjectId Id { get; set; }
        /// <summary>
        /// Username is "primary key" here
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Email Id of the user
        /// </summary>
        public string email { get; set; }

        /// <summary>
        /// Password of the user
        /// </summary>
        public string password { get; set; }
    }
}