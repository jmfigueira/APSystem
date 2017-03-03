using BL;
using Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace WS.APSystem.Controllers
{
    public class PassageController : ApiController
    {
        private PassageService _context = new PassageService();

        [HttpGet]
        public List<Passage> GetAll()
        {
            return _context.Select(string.Empty, string.Empty);
        }

        [HttpGet]
        public List<Passage> GetByCondition(string condition, string value)
        {
            return _context.Select(condition, value);
        }

        [HttpPost]
        public bool PostInsert([FromBody]Object value)
        {
            string json = JsonConvert.SerializeObject(value);
            Passage passage = JsonConvert.DeserializeObject<Passage>(json);

            return _context.Create(passage);
        }

        [HttpDelete]
        public bool Delete(string number)
        {
            return _context.Remove(number);
        }

        [HttpPost]
        public bool Update([FromBody]Object value)
        {
            string json = JsonConvert.SerializeObject(value);
            Passage passage = JsonConvert.DeserializeObject<Passage>(json);

            return _context.Update(passage);
        }
    }
}
