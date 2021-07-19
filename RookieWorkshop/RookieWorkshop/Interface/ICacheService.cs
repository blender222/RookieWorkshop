﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieWorkshop.Interface
{
    public interface ICacheService
    {
        string Get<T>(string key, TimeSpan expireTime, Func<T> getDataFunc);

        void Remove(string key);
    }
}
