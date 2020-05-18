using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson.Serialization.Serializers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    [BsonIgnoreExtraElements]
    public class User
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfNull]
        public Info person { get; set; }
        [BsonIgnoreIfNull]
        public string Nick { get; set; }
        [BsonIgnoreIfNull]
        public string Pass { get; set; }
        [BsonIgnoreIfNull]
        public List<string> Followers { get; set; }
        [BsonIgnoreIfNull]
        public List<string> Following { get; set; }
        
    }
}

