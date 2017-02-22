using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL
    {
        private readonly APSystemEntities _context;

        public UserDAL()
        {
            _context = new APSystemEntities();
        }

        public UserDAL(APSystemEntities context)
        {
            _context = context;
        }

        public Boolean Insert(Model.User user)
        {
            try
            {
                User u = new User
                {
                    CPF = user.CPF,
                    Login = user.Login,
                    Password = user.Password,
                    RG = user.RG
                };

                _context.User.Add(u);

                return true;
            }
            catch
            {
                //TODO: Tratar as possívels execeções
                return false;
            }
        }

        public Boolean Remove(Model.User user)
        {
            try
            {
                User u = _context.User.Where(x => x.Login == user.Login).FirstOrDefault();

                _context.User.Remove(u);

                return true;
            }
            catch
            {
                //TODO: Tratar as possívels execeções
                return false;
            }
        }

        public List<Model.User> SelectAll()
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                foreach (var user in _context.User.ToList())
                {
                    Model.User u = new Model.User
                    {
                        Id = user.Id,
                        CPF = user.CPF,
                        Login = user.Login,
                        Password = user.Password,
                        RG = user.RG,
                    };

                    users.Add(u);
                }

                return users;
            }
            catch
            {
                //TODO: Tratar as possívels execeções
                return null;
            }
        }

        public List<Model.User> SelectByCondition(string condition)
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                foreach (var user in _context.User.SqlQuery(condition))
                {
                    Model.User u = new Model.User
                    {
                        Id = user.Id,
                        CPF = user.CPF,
                        Login = user.Login,
                        Password = user.Password,
                        RG = user.RG,
                    };

                    users.Add(u);
                }

                return users;
            }
            catch
            {
                //TODO: Tratar as possívels execeções
                return null;
            }
        }
    }
}
