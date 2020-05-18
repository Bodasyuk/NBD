using DAL.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositoriy
{
    //user repository
    public class UR
    {
        IMongoDatabase database;
        IMongoCollection<User> Ucoll;
        IMongoCollection<BsonDocument> Bcoll;
        public UR()
        {
            database = Connect.GetDefaultDatabase();
            Ucoll = database.GetCollection<User>(GetTableName());
            Bcoll = database.GetCollection<BsonDocument>(GetTableName());
        }
        private string GetTableName()
        {
            return "users";
        }
        public void Add(User user) =>
            Ucoll.InsertOne(user);

        public void Add(IEnumerable<User> entities) =>
            Ucoll.InsertMany(entities);

        public void Update(string nickname, User user) =>
            Ucoll.ReplaceOne(entity => entity.Nick == nickname, user);

        public void Update(ObjectId id, User user) =>
            Ucoll.ReplaceOne(entity => entity.Id == id, user);

        public void Delete(ObjectId id) =>
            Ucoll.DeleteOne(entity => entity.Id == id);
        public List<User> GetUsers()
        {
            var usersDoc = Bcoll.Find(new BsonDocument()).ToList();
            List<User> users = new List<User>();
            foreach (var elem in usersDoc)
            {
                users.Add(BsonSerializer.Deserialize<User>(elem));
            }
            return users;

        }

        public void UpdateMail(string nickname, string mail)
        {
            User user = Ucoll.Find(entity => entity.Nick == nickname).FirstOrDefault();
            user.person.Mail = mail;
            Ucoll.ReplaceOne(entity => entity.Nick == nickname, user);
        }



        public ObjectId GetUserId(string nickname)
        {
            var user = Ucoll.Find(entity => entity.Nick == nickname).FirstOrDefault();
            return user.Id;
        }
        public User GetUserByNick(string nickname)
        {
            var user = Ucoll.Find(entity => entity.Nick == nickname).FirstOrDefault();
            return user;
        }
        public User GetUserById(ObjectId id)
        {
            var user = Ucoll.Find(entity => entity.Id == id).FirstOrDefault();
            return user;
        }
        //public List<Info> GetInfo(string nickname)
        //{
        //    var user = Ucoll.Find(entity => entity.Nick == nickname).FirstOrDefault();
        //    return user.person;
        //}
        public void UpdateField(string nickname, string FieldToEdit, string FieldValue)
        {
            var filter = Builders<User>.Filter.Eq("Nick", nickname);
            var update = Builders<User>.Update.Set(FieldToEdit, FieldValue);
            Ucoll.UpdateOne(filter, update);
        }
        public void UpdateFieldFollow(string nickname, string FieldToEdit, List<string> FieldValue)
        {
            var filter = Builders<User>.Filter.Eq("Nick", nickname);
            var update = Builders<User>.Update.Set(FieldToEdit, FieldValue);
            Ucoll.UpdateOne(filter, update);
        }
        public void UpdateFieldInfo(string nickname, string FieldToEdit, Info FieldValue)
        {
            var filter = Builders<User>.Filter.Eq("Nick", nickname);
            var update = Builders<User>.Update.Set(FieldToEdit, FieldValue);
            Ucoll.UpdateOne(filter, update);
        }

        public void FollowDelete(string id)
        {
            var filter1 = Builders<User>.Filter.Eq("Follows", id);
            var filter2 = Builders<User>.Filter.Eq("Following", id);

            Ucoll.DeleteOne(filter1);
            Ucoll.DeleteOne(filter2);
        }

        public void AddFollower(string nickname, string newFollower)
        {
            var filter = Builders<User>.Filter.Eq("Nick", nickname);
            var update = Builders<User>.Update.Push("Followers", newFollower);
            Ucoll.UpdateOne(filter, update);
        }

        public void AddFollowing(string nickname, string newFollowing)
        {
            var filter = Builders<User>.Filter.Eq("Nick", nickname);
            var update = Builders<User>.Update.Push("Following", newFollowing);
            Ucoll.UpdateOne(filter, update);
        }

    }
}
