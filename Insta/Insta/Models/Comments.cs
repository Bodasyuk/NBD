using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Comments
    {
        [BsonIgnoreIfNull]
        public ObjectId OwnerId { get; set; }
        [BsonIgnoreIfNull]
        public string comm { get; set; }
    }
}
