using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravelCore.Entities
{
    public class Supporter
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string SupporterId { get; set; }
        public string SupporterName { get; set; }
        public string SupporterImg { get; set; }


    }
}
