﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using RookieWorkshop.Interface;
using RookieWorkshop.Service;

namespace RookieWorkshop.CrossLayer
{
    public class DataModule : Autofac.Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RandomService>().As<IInputService>().SingleInstance();
            builder.RegisterType<FooBarQixService>().As<IDataService>().SingleInstance();
        }
    }
}
