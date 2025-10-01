﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravelCore.Entities
{
    public class ReceiverMessage
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ReceiverMessageId { get; set; }
        public string PhoneNumber { get; set; }
        public string Message { get; set; } 
        public string Email { get; set; }
        public string NameSurname { get; set; }
        public DateTime ReceiverDate { get; set; }
        public bool Status { get; set; }


    }
}
