using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace DAL.Models
{
    [BsonIgnoreExtraElements]
    public class Info
    { 

        [BsonIgnoreIfNull]
        public string Name { get; set; }
        [BsonIgnoreIfNull]
        public string Surname { get; set; }
        [BsonIgnoreIfNull]
        public string Mail { get; set; }
    }
}
