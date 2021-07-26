using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using RookieWorkshop.Context;
using RookieWorkshop.Repository.FooBarQix;
using RookieWorkshop.Service;
using RookieWorkshop.Service.DataHub;
using RookieWorkshop.Service.Utility;

namespace RookieWorkshop.CrossLayer
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RandomService>().As<IInputService>().SingleInstance();
            builder.RegisterType<FooBarQixService>().As<IDataService>().SingleInstance();

            builder.RegisterType<FooBarQixRepository>().As<IFooBarQixRepository>();
            builder.RegisterType<DataDbContext>().As<DataDbContext>();
        }
    }
}
