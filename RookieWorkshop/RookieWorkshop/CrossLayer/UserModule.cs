using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using RookieWorkshop.Service;
using RookieWorkshop.Service.WebUser;

namespace RookieWorkshop.CrossLayer
{
    public class UserModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<UserService>().As<IUserService>();
        }
    }
}
