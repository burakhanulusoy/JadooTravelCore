using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.ComponentModel.DataAnnotations;

namespace JadooTravelCore.Entities
{

    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string UserId { get; set; }
        public string UserName { get; set; }
        [MinLength(8,ErrorMessage ="Şifre minumum 8 karakterli olmak zorundadır.")]
        public string UserPassword { get; set; }

        public string ImgUrl { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Mission { get; set; }
        public string City { get; set; }




    }
}
