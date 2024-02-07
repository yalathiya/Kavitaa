using MongoDB.Bson;

namespace Kavita.Models
{
    /// <summary>
    /// This class represents model of users.
    /// </summary>
    public class Users
    {
        /// <summary>
        /// Default Object Id
        /// </summary>
        public ObjectId _id { get; set; }

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