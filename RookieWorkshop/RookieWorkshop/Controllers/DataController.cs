using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RookieWorkshop.Model;
using RookieWorkshop.Service.DataHub;
using RookieWorkshop.Service.WebUser;

namespace RookieWorkshop.Controllers
{
    [ApiController]
    [Route("api")]
    public class DataController : Controller
    {
        private readonly IDataService _dataService;
        private readonly IUserService _userService;

        public DataController(IDataService dataService, IUserService userService)
        {
            _dataService = dataService;
            _userService = userService;
        }

        [HttpGet, Route("user")]
        public string GetUser()
        {
            List<User> userList = _userService.GetUser();
            
            return JsonSerializer.Serialize(userList);
        }

        [HttpGet("getData/{input}")]
        public string GetData(string input)
        {
            string result = _dataService.GetData(input);

            return result;
        }

        [HttpGet("getDataAndSave/{input}")]
        public string GetDataAndSave(string input)
        {
            string result = _dataService.GetDataAndSave(input);

            return result;
        }
    }
}
