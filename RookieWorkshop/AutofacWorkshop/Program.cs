using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;

namespace AutofacWorkshop
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<HankDriverService>().As<IDriverService>();
            builder.RegisterType<BMWCarService>().As<ICarService>();

            var container = builder.Build();

            using (var scope = container.BeginLifetimeScope())
            {
                var carService = scope.Resolve<ICarService>();

                carService.Drive();
            }

            Console.ReadKey();
        }
    }

    //Interface
    public interface ICarService
    {
        void Drive();
    }
    public interface IDriverService
    {
        string SayName();
    }

    //Class
    public class BMWCarService : ICarService
    {
        private readonly IDriverService _driverService;

        public BMWCarService(IDriverService driverService)
        {
            this._driverService = driverService;
        }

        public void Drive()
        {
            var driverName = this._driverService.SayName();

            Console.Write($"{driverName} drive BMW");
        }
    }

    public class HankDriverService : IDriverService
    {
        public string SayName()
        {
            Console.WriteLine("My name is Hank");
            return "Hank";
        }
    }
}
