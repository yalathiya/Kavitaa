using Kavita.Connection;
using Kavita.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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
            var maxKavitaId = _collectionKavita.AsQueryable().Max(k => k.kavitaId);
            objKavita.kavitaId = maxKavitaId + 1;

            _collectionKavita.InsertOne(objKavita);
        }

        internal Models.Kavita DeleteKavita(int kavitaId)
        {
            var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", kavitaId);
            return _collectionKavita.FindOneAndDelete(filter);
        }

        internal Models.Kavita GetKavita(int kavitaId)
        {
            var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", kavitaId);

            Kavita.Models.Kavita objKavita = _collectionKavita.Find(filter).FirstOrDefault();
            return objKavita;
        }

        internal void UpdateKavita(Models.Kavita objKavita)
        {
            var filter = Builders<Kavita.Models.Kavita>.Filter.Eq("kavitaId", objKavita.kavitaId);

            var update = Builders<Kavita.Models.Kavita>.Update
                .Set("title", objKavita.title)  
                .Set("content", objKavita.content)
                .Set("category", objKavita.category);

            _collectionKavita.UpdateOne(filter, update);
        }
    }
}