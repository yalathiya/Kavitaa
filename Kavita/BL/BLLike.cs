using Kavita.Authentication;
using Kavita.Connection;
using Kavita.Models;
using MongoDB.Driver;
using System;
using System.Linq;
using System.Security.Claims;
using System.Web;

namespace Kavita.BL
{
    public class BLLike
    {
        // Selecting user collection from the database 
        IMongoCollection<Kavita.Models.Kavita> _collectionKavita;
        IMongoCollection<Likes> _collectionLikes;
        IMongoCollection<Users> _collectionUsers;

        public BLLike()
        {
            _collectionKavita = Connect.GetCollection<Kavita.Models.Kavita>("Kavita");
            _collectionLikes = Connect.GetCollection<Likes>("Likes");
            _collectionUsers = Connect.GetCollection<Users>("Users");
        }

        internal void Like(int kavitaId)
        {
                // Check if the user and kavita exist
                var username = CurrentUser.GetUsername();
                var userExists = _collectionUsers.Find(user => user.username == username).Any();
                var kavitaExists = _collectionKavita.Find(kavita => kavita.kavitaId == kavitaId).Any();

                if (userExists && kavitaExists)
                {
                    // Check if the user has already liked the kavita
                    var existingLike = _collectionLikes.Find(like => like.username == username && like.kavitaId == kavitaId).FirstOrDefault();

                    if (existingLike == null)
                    {
                        // User hasn't liked this kavita yet, so we can add a new like
                        var like = new Likes
                        {
                            username = username,
                            kavitaId = kavitaId
                        };

                        // Add like to Likes collection
                        _collectionLikes.InsertOne(like);

                        // Update like in kavita 
                        var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", kavitaId);
                        var update = Builders<Kavita.Models.Kavita>.Update.Inc("like", 1);

                        _collectionKavita.UpdateOne(filter, update);
                    }
                    else
                    {
                        // User has already liked this kavita 
                        // No action is performed
                    }
                }
                else
                {
                    // User or kavita not found, handle accordingly (throw an exception, log, etc.)
                    throw new InvalidOperationException("User or kavita not found.");
                }
            
        }

        internal void Unlike(int kavitaId)
        {
            
                // Check if the user and kavita exist
                var username = CurrentUser.GetUsername();
                var userExists = _collectionUsers.Find(user => user.username == username).Any();
                var kavitaExists = _collectionKavita.Find(kavita => kavita.kavitaId == kavitaId).Any();

                if (userExists && kavitaExists)
                {
                    // Find and remove the like entry for the specified user and kavitaId
                    var deleteResult = _collectionLikes.DeleteOne(like => like.username == username && like.kavitaId == kavitaId);

                    // Update like value in kavita collection
                    if (deleteResult.DeletedCount > 0)
                    {
                        var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", kavitaId);
                        var update = Builders<Kavita.Models.Kavita>.Update.Inc("like", -1);

                        _collectionKavita.UpdateOne(filter, update);
                    }
                    // No like entry found to delete
                    // No action performed if user has not liked it.
                }
                else
                {
                    // User or kavita not found, handle accordingly (throw an exception, log, etc.)
                    throw new InvalidOperationException("User or kavita not found.");
                }
            
        }     
    }
}
