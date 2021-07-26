using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RookieWorkshop.Service.DataHub
{
    public interface IDataService
    {
        string GetData(string input, bool isCleanCache = false);
        string GetDataAndSave(string input, bool isCleanCache = false);
    }
}
