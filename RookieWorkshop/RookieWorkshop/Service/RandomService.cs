using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Interface;

namespace RookieWorkshop.Service
{
    public class RandomService : IInputService
    {
        private readonly Random rdn = new Random();
        public int GetValue(int max)
        {
            int result = this.rdn.Next(max + 1);

            return result;
        }
    }
}
