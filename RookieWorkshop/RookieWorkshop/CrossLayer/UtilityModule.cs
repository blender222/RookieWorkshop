using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using RookieWorkshop.Interface;
using RookieWorkshop.Service;

namespace RookieWorkshop.CrossLayer
{
    public class UtilityModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<CacheService>().As<ICacheService>().SingleInstance();
        }
    }
}
