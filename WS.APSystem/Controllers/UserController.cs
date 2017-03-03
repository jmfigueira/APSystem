﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BL;
using Model;
using System.Xml;
using System.Web.Helpers;
using Newtonsoft.Json;

namespace WS.APSystem.Controllers
{
    public class UserController : ApiController
    {
        private UserService _context = new UserService();
        
        [HttpGet]
        public List<User> GetAll()
        {
            return _context.Select(string.Empty, string.Empty);
        }

        [HttpGet]
        public List<User> GetByCondition(string condition, string value)
        {
            return _context.Select(condition, value);
        }

        [HttpPost]
        public bool PostInsert([FromBody]Object value)
        {
            string json = JsonConvert.SerializeObject(value);
            User user = JsonConvert.DeserializeObject<User>(json);

            return _context.Create(user);
        }

        [HttpDelete]
        public bool Delete(string login)
        {
            return _context.Remove(login);
        }

        [HttpPost]
        public bool Update([FromBody]Object value)
        {
            string json = JsonConvert.SerializeObject(value);
            User user = JsonConvert.DeserializeObject<User>(json);

            return _context.Update(user);
        }
    }
}