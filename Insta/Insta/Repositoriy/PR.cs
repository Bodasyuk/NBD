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
    public class PR
    {
        IMongoDatabase database;
        IMongoCollection<Posts> Pcoll;
        IMongoCollection<BsonDocument> Bcoll;
        

        public PR()
        {
            database = Connect.GetDefaultDatabase();
            Pcoll = database.GetCollection<Posts>(GetTableName());
            Bcoll = database.GetCollection<BsonDocument>(GetTableName());
        }

        private string GetTableName()
        {
            return "posts";
        }

        public void AddPost(Posts post) =>
            Pcoll.InsertOne(post);

        public void AddPost(IEnumerable<Posts> entities) =>
            Pcoll.InsertMany(entities);

        public void UpdatePost(ObjectId id, Posts post) =>
            Pcoll.ReplaceOne(entity => entity.Id == id, post);

        public void Delete(ObjectId id) =>
            Pcoll.DeleteOne(entity => entity.Id == id);
        
        public void DeleteComment(ObjectId Postid, Comments commm) {

            var filter = Builders<Posts>.Filter.Eq("_id", Postid);
            var update = Builders<Posts>.Update.Pull("Comments", commm);
            Pcoll.UpdateOne(filter, update);
        }

        //public void DeleteAllComment(ObjectId id)
        //{
        //    List<Comments> list = new List<Comments>();
        //    var usersDoc = Bcoll.Find(new BsonDocument()).ToList();
        //    List<Posts> post = new List<Posts>();
        //    foreach (var elem in usersDoc)
        //    {
        //        post.Add(BsonSerializer.Deserialize<Posts>(elem));
        //    }

        //    foreach (var elem in post)
        //    {
                
        //        list = elem.comment;
                
        //    }
        //    list.Remove()
        //}
        public void UpdateLikes(ObjectId Postid , bool button)
        {
            Posts post = Pcoll.Find(entity => entity.Id == Postid).FirstOrDefault();
            if (button)
            {
                post.likes += 1;
            }
            else
            {
                post.likes -= 1;
            }
            Pcoll.ReplaceOne(entity => entity.Id == Postid, post);

        }


            public void UpdateComment(ObjectId Postid, string OldComm, string NewComm, ObjectId id)
        {

            var filter = Builders<Posts>.Filter.Eq("Id", Postid);
            var update = Builders<Posts>.Update.Push("Comments", NewComm);
            Pcoll.UpdateOne(filter, update);

        }
        public void AddComment(ObjectId Postid, ObjectId Userid, string Comment)
        {

            Posts post;
            Comments commen=new Comments();
            post = Pcoll.Find(entity => entity.Id == Postid).FirstOrDefault();
            commen.OwnerId = Userid;
            commen.comm = Comment;
            post.comment.Add(commen);
            Pcoll.ReplaceOne(entity => entity.Id == Postid, post);
        }

            public List<Posts> GetPosts()
        {
            var usersDoc = Bcoll.Find(new BsonDocument()).ToList();
            List<Posts> post = new List<Posts>();
            foreach (var elem in usersDoc)
            {
                post.Add(BsonSerializer.Deserialize<Posts>(elem));
            }
            return post;

        }


        public Posts GetPostsById(ObjectId id)
        {
            var post = Pcoll.Find(entity => entity.Id == id).FirstOrDefault();
            return post;
        }
        public ObjectId GetPostId(ObjectId Userid)
        {
            var post = Pcoll.Find(entity => entity.UserId == Userid).FirstOrDefault();
            return post.Id;
        }
        public List<Posts> GetPostsByUserId(ObjectId id)
        {
            var usersDoc = Bcoll.Find(new BsonDocument()).ToList();
            List<Posts> post = new List<Posts>();
            List<Posts> post1 = new List<Posts>();
            foreach (var elem in usersDoc)
            {
                post.Add(BsonSerializer.Deserialize<Posts>(elem));
            }
            foreach (var elem in post)
            {
                if (id == elem.UserId)
                {
                    post1.Add(elem);
                }
            }
            return post1;
        }
    }
}
