using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Interface;
using RookieWorkshop.Model;

namespace RookieWorkshop.Service
{
    public class UserService : IUserService
    {
        public List<User> GetUser()
        {
            List<User> userList = new List<User>
            {
                new User { Id = 1, Name = "Alpha", Age = 111 },
                new User { Id = 2, Name = "Beta", Age = 222 }
            };
            return userList;
        }
    }
}
