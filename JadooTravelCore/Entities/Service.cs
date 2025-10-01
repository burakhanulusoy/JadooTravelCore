using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravelCore.Entities
{
    public class Service
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string ServiceId { get; set; }
        public string CardTitle { get; set; }
        public string CardDescription { get; set; }
        public string CardImgUrl { get; set; }



    }
}
