using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieWorkshop.Service.Utility
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
