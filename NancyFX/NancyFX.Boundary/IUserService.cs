using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NancyFX.Model;

namespace NancyFX.Boundary
{
    public interface IUserService
    {
        User GetUser(int id);
        int AddUser(string name,int age);
        int GetUserId();
        List<User> DeleteUser(int id);
        List<User> GetAllUsers();
    }
}
