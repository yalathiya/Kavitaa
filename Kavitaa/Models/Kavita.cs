using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Kavitaa.Models
{
    /// <summary>
    /// Class Kavita represents a model which has all details about kavita
    /// </summary>
    public class Kavita
    {
        /// <summary>
        /// Kavita Id "PRIMARY KEY"
        /// </summary>
        public int kavitaId { get; set; }

        /// <summary>
        /// Title of Kavita
        /// </summary>
        public string title { get; set; }

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