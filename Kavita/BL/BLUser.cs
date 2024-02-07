using Kavita.Authentication;
using Kavita.Connection;
using Kavita.Models;
using Kavita.Security;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Kavita.BL
{

    /// <summary>
    /// It provides buisness logic of functionalities related user
    /// </summary>
    public class BLUser
    {
        // Selecting user collection from database 
        IMongoCollection<Users> _collectionUser;
        public BLUser() 
        { 
            _collectionUser = Connect.GetCollection<Users>("Users");
        }

        /// <summary>
        /// Convert json data to bson data & adds it into MongoDb
        /// </summary>
        /// <param name="objUsers"> User details which will be added </param>
        internal void AddUser(Users objUsers)
        {
            var filter = Builders<Users>.Filter.Eq("username", objUsers.username);
            var obj= _collectionUser.Find(filter).FirstOrDefault();
            if(obj != null)
            {
                throw new Exception("Username already present");
            }

            // Encrypt the password by using Aes Algorithm
            // Encrypted password will be stored in database

            AesAlgo aes = new AesAlgo();
            string _encryptedPassword = aes.Encrypt(objUsers.password);
            objUsers.password = _encryptedPassword;

            _collectionUser.InsertOne(objUsers);

        }

        internal Users DeleteUser()
        {
             var filter = Builders<Users>.Filter.Eq("username", CurrentUser.GetUsername());
             return _collectionUser.FindOneAndDelete(filter);
        }

        internal Users GetUser()
        {
            
            var filter = Builders<Users>.Filter.Eq("username", CurrentUser.GetUsername());

            Users objUsers = _collectionUser.Find(filter).FirstOrDefault();
            return objUsers;

        }

        internal void UpdateUser(Users objUsers)
        {
            
                var filter = Builders<Users>.Filter.Eq("username", CurrentUser.GetUsername());

                var update = Builders<Users>.Update
                    .Set("email", objUsers.email)
                    .Set("password", objUsers.password);

                _collectionUser.UpdateOne(filter, update);
           
        }
    }
}