using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BL
{
    public class UserService
    {
        private readonly DAL.UserDAL _userDAL;

        public UserService()
        {
            _userDAL = new DAL.UserDAL();
        }

        public UserService(DAL.UserDAL context)
        {
            _userDAL = context;
        }

        //TODO: Testar esse método
        public Boolean CreateUser(string login, string password, string cpf, string rg)
        {
            try
            {
                User user = Select("Login", login);

                if (user == null)
                {
                    user = new User()
                    {
                        Login = login,
                        Password = password,
                        RG = rg,
                        CPF = cpf
                    };
                }

                return _userDAL.Insert(user);
            }
            catch
            {
                //TODO: Tratar as possível exceções
                return false;
            }
        }

        //TODO: Testar esse método
        public Boolean RemoveUser(string login)
        {
            try
            {
                User user = Select("Login", login);

                return _userDAL.Remove(user);
            }
            catch
            {
                //TODO: Tratar as possível exceções
                return false;
            }
        }

        public User Select(string condition, string value)
        {
            string query = string.Format("WHERE [{0}] = {1}", condition, value);

            return _userDAL.SelectByCondition(query).First();
        }

        public List<User> Select()
        {
            return _userDAL.SelectAll();
        }
    }
}
