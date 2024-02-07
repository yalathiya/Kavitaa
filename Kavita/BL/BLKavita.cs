using Kavita.Authentication;
using Kavita.Connection;
using MongoDB.Driver;
using System;
using System.Linq;

namespace Kavita.BL
{
    /// <summary>
    /// It provides buisness logic of functionalities related kavita
    /// </summary>
    public class BLKavita
    {
        // Selecting user collection from database 
        IMongoCollection<Kavita.Models.Kavita> _collectionKavita;
        public BLKavita()
        {
            _collectionKavita = Connect.GetCollection<Kavita.Models.Kavita>("Kavita");
        }

        internal void AddKavita(Models.Kavita objKavita)
        {
            // Set current username & like = 0
            objKavita.username = CurrentUser.GetUsername();
            objKavita.like = 0;

            var maxKavitaId = _collectionKavita.AsQueryable().Max(k => k.kavitaId);
            objKavita.kavitaId = maxKavitaId + 1;

            _collectionKavita.InsertOne(objKavita);
        }

        internal Models.Kavita DeleteKavita(int kavitaId)
        {
            var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", kavitaId);
            if(_collectionKavita.Find(filter).FirstOrDefault().username == CurrentUser.GetUsername())
            {
                return _collectionKavita.FindOneAndDelete(filter);
            }
            // User is trying to delete a kavita which is not published by him/her
            else
            {
                throw new Exception("You're trying to update a poem which is not published by you");
            }

        }

        internal Models.Kavita GetKavita(int kavitaId)
        {
            var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", kavitaId);

            Kavita.Models.Kavita objKavita = _collectionKavita.Find(filter).FirstOrDefault();
            return objKavita;
        }

        internal void UpdateKavita(Models.Kavita objKavita)
        {
            if(objKavita.username == CurrentUser.GetUsername())
            {
                var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", objKavita.kavitaId);

                var update = Builders<Kavita.Models.Kavita>.Update
                    .Set("title", objKavita.title)
                    .Set("content", objKavita.content)
                    .Set("category", objKavita.category);

                _collectionKavita.UpdateOne(filter, update);
            }
            // User is trying to update a kavita which is not published by him/her
            else
            {
                throw new Exception("You're trying to update a poem which is not published by you");
            }
        }
    }
}