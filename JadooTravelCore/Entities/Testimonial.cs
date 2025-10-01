using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace JadooTravelCore.Entities
{
    public class Testimonial
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string TestimonialId { get; set; }
        public string Message { get; set; }
        public string NameSurname { get; set; }
        public string Job { get; set; }

        public string ImgUrl { get; set; }

    }
}
