using Kavitaa.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;

namespace Kavitaa.BL
{
    /// <summary>
    /// It provides business logic of functionalities related to the user
    /// </summary>
    public class BLUser
    {
        private IMongoCollection<Users> _collectionUser;

        public BLUser()
        {
            string connectionString = "mongodb+srv://yash_freecodecamp:CsQvSLYe6EMtPlqJ@cluster0.htzrrjd.mongodb.net/?retryWrites=true&w=majority";
            IMongoClient mongoClient = new MongoClient(connectionString);

            _collectionUser = mongoClient.GetDatabase("kavita").GetCollection<Users>("Users");
        }

        /// <summary>
        /// Convert JSON data to BSON data & adds it into MongoDB
        /// </summary>
        /// <param name="objUsers">User details which will be added</param>
        public void AddUser(Users objUsers)
        {
            
            _collectionUser.InsertOne(objUsers);
        }

        public Users DeleteUser(string username)
        {
            throw new NotImplementedException();
        }

        public Users GetUser(string username)
        {
            var filter = Builders<Users>.Filter.Eq("yalathiya", username);
            return _collectionUser.Find(filter).FirstOrDefault();
        }

        public void UpdateUser(Users objUsers)
        {
            throw new NotImplementedException();
        }
    }
}
