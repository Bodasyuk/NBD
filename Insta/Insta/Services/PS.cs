using DAL.Models;
using DAL.Repositoriy;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Insta.Services
{
    public class PS
    {
        public bool CheckComm(string comm, ObjectId id, ObjectId OwnerId)
        {
            Posts post = new Posts();
            PR pr = new PR();
            post = pr.GetPostsById(id);
            
            foreach (var elem in post.comment)
            {
                if (elem.comm == comm && elem.OwnerId == OwnerId)
                {
                    return false;
                }
            }

            return true;
        }

    }
}
