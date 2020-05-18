using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using DAL.Models;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;
using DAL.Repositoriy;

namespace DAL.Services
{

    //user services
    public class US
    {

        UR rep;
        public US()
        {
            rep = new UR();
        }
        public bool CheckPassword(string nickname, string password)
        {

            User user = new User();
            user = rep.GetUserByNick(nickname);
            if (user != null)
            {
                if (user.Pass == password)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }
        public bool CheckMail(string nickname, string mail)
        {

            User users;
            users = rep.GetUserByNick(nickname);
            if (users.person.Mail == mail)
            {
                return true;
            }
            return false;
        }
        public bool CheckMail2(string mail)
        {

            List<User> users=new List<User>();
            users = rep.GetUsers();
            foreach (var el in users)
            {
                if (el.person.Mail == mail)
                {
                    return false;
                }
            }
            return true;
        }

        public bool CheckNick(string nickname)
        {
            List<User> users = new List<User>();
            users = rep.GetUsers();
            foreach (var elem in users)
            {
                if (elem.Nick == nickname)
                {
                    return false;
                }
            }

            return true;
        }
        //public void DeleteAllByID(string id)
        //{

        //    UR ur = new UR();


        //    ur.Delete(id);
        //    ur.FollowDelete(id);

        //}
        public bool CheckAlreadyFollow(string nickname, string usernickname)
        {
            UR ur = new UR();
            User user = new User();
            user = ur.GetUserByNick(nickname);
            if (user != null && user.Following != null)
            {
                foreach (var el in user.Following)
                {
                    if (el == usernickname)
                    {
                        return true;
                    }
                }
            }
            else
            {
                return false;
            }
            return false;
        }
        public void Follow(string nick1, string nick2)
        {
            UR ur = new UR();            
            ur.AddFollowing(nick1, nick2);
            ur.AddFollower(nick2, nick1);
        }
    }
}
