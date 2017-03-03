using BL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

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

        //[HttpGet]
        public List<User> GetByCondition(string condition, string value)
        {
            return _context.Select(condition, value);
        }

        //[HttpPost]
        public bool Insert([FromBody]Object value)
        {
            string json = JsonConvert.SerializeObject(value);
            User user = JsonConvert.DeserializeObject<User>(json);

            return _context.Create(user);
        }

        //[HttpDelete]
        public bool Delete(string login)
        {
            return _context.Remove(login);
        }

        //[HttpPost]
        public bool Update([FromBody]Object value)
        {
            string json = JsonConvert.SerializeObject(value);
            User user = JsonConvert.DeserializeObject<User>(json);

            return _context.Update(user);
        }
    }
}