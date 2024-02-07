using MongoDB.Bson;
using System;

namespace Kavita.Models
{
    /// <summary>
    /// Class Kavita represents a model which has all details about kavita
    /// </summary>
    public class Kavita
    {
        /// <summary>
        /// Default Object Id
        /// </summary>
        public ObjectId _id { get; set; }

        // <summary>
        /// Kavita Id
        /// </summary>
        public int kavitaId { get; set; }

        /// <summary>
        /// Title of Kavita
        /// </summary>
        public string title { get; set; }

        /// <summary>
        /// Username of Kavita publisher 
        /// </summary>
        public string username { get; set; }

        /// <summary>
        /// Content of Kavita
        /// </summary>
        public string content { get; set; }

        /// <summary>
        /// Date & Time when kavita is published
        /// </summary>
        public DateTime uploadedTime { get; set; }

        /// <summary>
        /// How many likes are given to this kavita 
        /// </summary>
        public long like { get; set; }

        /// <summary>
        /// Categoty of Kavita 
        /// String.Empty is used as any kavita can be published without specifying kavita name
        /// </summary>
        public string category { get; set; } = string.Empty;
    }
}