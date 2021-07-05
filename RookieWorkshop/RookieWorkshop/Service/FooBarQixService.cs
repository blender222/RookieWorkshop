using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Interface;

namespace RookieWorkshop.Service
{
    public class FooBarQixService : IDataService
    {
        private readonly IInputService _inputService;

        public FooBarQixService(IInputService inputService)
        {
            this._inputService = inputService;
        }

        public string GetData(int input)
        {
            //input = this._inputService.GetValue(input);

            string result = string.Empty;
            string inputStr = input.ToString();

            if (input % 3 == 0)
            {
                result += "Foo";
            }
            if (input % 5 == 0)
            {
                result += "Bar";
            }
            if (input % 7 == 0)
            {
                result += "Qix";
            }

            foreach (var digit in inputStr)
            {
                switch (digit)
                {
                    case '3':
                        result += "Foo";
                        break;
                    case '5':
                        result += "Bar";
                        break;
                    case '7':
                        result += "Qix";
                        break;
                    default:
                        break;
                }
            }

            if (result == string.Empty)
            {
                result = inputStr;
            }

            return result;
        }
    }
}
