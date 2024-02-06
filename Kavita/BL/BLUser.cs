﻿using Kavita.Connection;
using Kavita.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            _collectionUser.InsertOne(objUsers);
        }

        internal Users DeleteUser(string username)
        {
            var filter = Builders<Users>.Filter.Eq("username", username);
            return _collectionUser.FindOneAndDelete(filter);
        }

        internal Users GetUser(string username)
        {
            var filter = Builders<Users>.Filter.Eq("username", username);

            Users objUsers = _collectionUser.Find(filter).FirstOrDefault();
            return objUsers;

        }

        internal void UpdateUser(Users objUsers)
        {
            var filter = Builders<Users>.Filter.Eq("username", objUsers.username);

            var update = Builders<Users>.Update
                .Set("email", objUsers.email)
                .Set("password", objUsers.password)
                .Set("username", objUsers.username);

            _collectionUser.UpdateOne(filter, update);
        }
    }
}