using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieWorkshop.Service.DataHub
{
    public class FizzBuzzService : IDataService
    {
        public string GetData(string input, bool isCleanCache)
        {
            int num = int.Parse(input);

            string result;

            if (num % 3 == 0 && num % 5 == 0)
            {
                result = "FizzBuzz";
            }
            else if (num % 3 == 0)
            {
                result = "Fizz";
            }
            else if (num % 5 == 0)
            {
                result = "Buzz";
            }
            else
            {
                result = num.ToString();
            }
            return result;
        }

        public string GetDataAndSave(string input, bool isCleanCache = false)
        {
            throw new NotImplementedException();
        }
    }
}
