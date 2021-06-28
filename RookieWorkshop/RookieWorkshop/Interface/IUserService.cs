using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Model;

namespace RookieWorkshop.Interface
{
    public interface IUserService
    {
        List<User> GetUser();
    }
}
