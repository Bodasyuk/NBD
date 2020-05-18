using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Posts
    {
        [BsonIgnoreIfDefault]
        public ObjectId Id { get; set; }
        [BsonIgnoreIfDefault]
        public ObjectId UserId { get; set; }
        [BsonIgnoreIfNull]
        public int likes { get; set; }
        [BsonIgnoreIfNull]
        public List<Comments> comment = new List<Comments>();
    }
}
