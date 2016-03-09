using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.ComponentModel.DataAnnotations;

namespace BlogbookMVC.Models
{
    public class User
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public String Id { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public String Content { get; set; }

    }
}