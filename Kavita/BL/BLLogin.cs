using Kavita.Connection;
using Kavita.Models;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Text;

namespace Kavita.BL
{
    /// <summary>
    /// It provides business logic for functionalities related to login
    /// </summary>
    public static class BLLogin
    {
        // Selecting the user collection from the database 
        private static readonly IMongoCollection<Users> _collectionUsers;

        static BLLogin()
        {
            _collectionUsers = Connect.GetCollection<Users>("Users");
        }

        /// <summary>
        /// Authenticate user based on username and password
        /// </summary>
        /// <param name="username">Username for authentication</param>
        /// <param name="password">Password for authentication</param>
        /// <returns>True if authentication is successful, false otherwise</returns>
        internal static bool Login(string username, string password)
        {
            try
            {
                // Implement your authentication logic here using MongoDB
                var user = _collectionUsers.Find(u => u.username == username && u.password == password).FirstOrDefault();

                // Check if the user is found in the database
                if (user != null)
                {
                    // Authentication successful
                    return true;
                }

                // Authentication failed
                return false;
            }
            catch (Exception ex)
            {
                // Handle exceptions (e.g., log or rethrow)
                Console.WriteLine($"Error during login: {ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// Perform user logout (if needed)
        /// </summary>
        internal static void Logout()
        {
            // Implement logout logic if necessary
            // For example, you may need to invalidate a token or clear session data
            // This method is currently empty as it depends on your specific requirements
        }
    }
}
