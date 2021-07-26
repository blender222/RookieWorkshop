using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Model;

namespace RookieWorkshop.Service.WebUser
{
    public interface IUserService
    {
        List<User> GetUser();
    }
}
