﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RookieWorkshop.Service.Cache;
using RookieWorkshop.Service.Utility;
using RookieWorkshop.Repository.FooBarQix;
using RookieWorkshop.Table;

namespace RookieWorkshop.Service.DataHub
{
    public class FooBarQixService : IDataService
    {
        private readonly IFooBarQixRepository _fooBarQixRepository;

        private readonly IInputService _inputService;

        private readonly ICacheService _cacheService;

        public FooBarQixService(IFooBarQixRepository fooBarQixRepository, IInputService inputService, ICacheService cacheService)
        {
            this._fooBarQixRepository = fooBarQixRepository;
            this._inputService = inputService;
            this._cacheService = cacheService;
        }

        public string GetData(string input, bool isCleanCache)
        {
            string key = input;

            if (isCleanCache)
            {
                this._cacheService.Remove(key);
            }

            return this._cacheService.Get<string>(
                key,
                TimeSpan.FromSeconds(10),
                () =>
                {
                    string result = string.Empty;
                    int num = int.Parse(input);

                    if (num % 3 == 0)
                    {
                        result += "Foo";
                    }
                    if (num % 5 == 0)
                    {
                        result += "Bar";
                    }
                    if (num % 7 == 0)
                    {
                        result += "Qix";
                    }

                    foreach (var digit in num.ToString())
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
                        result = num.ToString();
                    }

                    return result;
                });
        }

        public string GetDataAndSave(string input, bool isCleanCache = false)
        {
            var result = this.GetData(input, isCleanCache);
            var data = new Data
            {
                Data_Input = input,
                Data_Result = result,
            };

            this._fooBarQixRepository.Insert(data);

            return result;
        }

        //public string GetData(int input)
        //{
        //    input = this._inputService.GetValue(input);

        //    string result = string.Empty;
        //    string inputStr = input.ToString();

        //    if (input % 3 == 0)
        //    {
        //        result += "Foo";
        //    }
        //    if (input % 5 == 0)
        //    {
        //        result += "Bar";
        //    }
        //    if (input % 7 == 0)
        //    {
        //        result += "Qix";
        //    }

        //    foreach (var digit in inputStr)
        //    {
        //        switch (digit)
        //        {
        //            case '3':
        //                result += "Foo";
        //                break;
        //            case '5':
        //                result += "Bar";
        //                break;
        //            case '7':
        //                result += "Qix";
        //                break;
        //            default:
        //                break;
        //        }
        //    }

        //    if (result == string.Empty)
        //    {
        //        result = inputStr;
        //    }

        //    return result;
        //}
    }
}
