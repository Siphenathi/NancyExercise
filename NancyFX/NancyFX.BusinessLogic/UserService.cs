using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NancyFX.Boundary;
using NancyFX.Model;

namespace NancyFX.BusinessLogic
{
    public class UserService:IUserService
    {
        private static readonly List<User> Users = new List<User>(new List<User>()
        {
            new User
            {
                Id = 1,
                Name = "xxx",
                Age = 37
            },
            new User
            {
                Id = 2,
                Name = "yyy",
                Age = 32
            }

        });
        public User GetUser(int id)
        {
            var user = Users.SingleOrDefault(x => x.Id == id);
            return user;
        }
        public int AddUser(string name, int age)
        {
            User user = new User
            {
                Id = GetUserId(),
                Name = name,
                Age = age
            };
            Users.Add(user);
            return user.Id;
        }
        public int GetUserId()
        {
            var count = Users.Count();
            count++;
            return count;
        }
        public List<User> DeleteUser(int id)
        {
            var user = Users.Find(x => x.Id == id);
            Users.Remove(user);
            return Users;
        }
        public List<User> GetAllUsers()
        {
            return Users;
        }
    }
}
