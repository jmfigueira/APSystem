using System.Collections.Generic;
using System.Web.Http;
using BL;
using Model;

namespace WS.APSystem.Controllers
{
    public class UserController : ApiController
    {
        private UserService _context = new UserService();

        public List<User> GetAllUsers()
        {
            return _context.Select(string.Empty, string.Empty);
        }

        public List<User> GetUsersByCondition(string condition, string value)
        {
            return _context.Select(condition, value);
        }

        public bool PostUser(string login, string password, string cpf, string rg)
        {
            return _context.CreateUser(login, password, cpf, rg);
        }
    }
}