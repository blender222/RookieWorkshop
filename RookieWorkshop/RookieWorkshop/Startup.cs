using System;
using System.Collections.Generic;
using System.Linq;
using Autofac;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RookieWorkshop.CrossLayer;
using RookieWorkshop.Interface;
using RookieWorkshop.Service;
//using Autofac;

namespace RookieWorkshop
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            //services.AddTransient<IDataService, FooBarQixService>();
            //services.AddTransient<IUserService, UserService>();
            //services.AddTransient<IInputService, RandomService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //builder.RegisterType<UserService>().As<IUserService>();
            //builder.RegisterType<FooBarQixService>().As<IDataService>();
            //builder.RegisterType<RandomService>().As<IInputService>();

            builder.RegisterModule<DataModule>();
            builder.RegisterModule<UserModule>();
            builder.RegisterModule<UtilityModule>();
        }
    }
}
