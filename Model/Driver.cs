using System;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace API_JERH.Models
{
    public class Driver
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id{get; set;} = string.Empty;
        
        [BsonElement("Name")]
        public string Name {get;set;} = string.Empty;
        [BsonElement("Number")]
        public int Number {get; set;}
        [BsonElement("Team")]
        public string Team {get; set;} = string.Empty;
    }
}