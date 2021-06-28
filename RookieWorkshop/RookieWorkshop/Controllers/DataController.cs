﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using RookieWorkshop.Model;
using RookieWorkshop.Interface;

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
        [HttpGet("data/{num}")]
        public string GetData(int num)
        {
            string result = _dataService.GetData(num);

            return result;
        }
    }
}
