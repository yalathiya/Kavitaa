using MongoDB.Bson;

namespace Kavita.Models
{
    /// <summary>
    /// This class represents model of Likes..
    /// This class is required because there is a constraint that 
    /// any user can like Kavita once and that should also visible to user.
    /// </summary>
    public class Likes
    {
        /// <summary>
        /// Default Object Id
        /// </summary>
        public ObjectId _id { get; set; }

        /// <summary>
        /// Id of kavita in Kavita- Model
        /// </summary>
        public long kavitaId {get; set;}

        /// <summary>
        /// Username which likes kavita
        /// </summary>
        public string username { get; set;}
    }
}