using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BL
{
    public class UserService :  IService<User>
    {
        #region .: Attributes :.
        private readonly DAL.UserDAL _userDAL;
        #endregion

        #region .: Constructors :.
        public UserService()
        {
            _userDAL = new DAL.UserDAL();
        }

        public UserService(DAL.UserDAL context)
        {
            _userDAL = context;
        }
        #endregion

        #region .: Public Methods :.
        //TODO: Testar esse método
        public bool Create(User value)
        {
            try
            {
                var result = Select("Login", value.Login);
                User user = result.Count > 0 ? result.First() : null;

                if (user == null)
                {
                    user = new User()
                    {
                        Login = value.Login,
                        Password = value.Password,
                        RG = value.RG,
                        CPF = value.CPF
                    };
                    return _userDAL.Insert(user);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }

        //TODO: Testar esse método
        public bool Remove(string login)
        {
            try
            {
                User user = Select("Login", login).First();

                return _userDAL.Remove(user);
            }
            catch
            {
                return false;
            }
        }

        public List<User> Select(string condition, string value)
        {
            try
            {
                if (!String.IsNullOrEmpty(condition) || !String.IsNullOrEmpty(value))
                {
                    string query = string.Format("SELECT * FROM dbo.[User] WHERE [{0}] = '{1}'", condition, value);

                    return _userDAL.SelectByCondition(query);
                }
                return _userDAL.SelectAll();
            }
            catch
            {
                return null;
            }
        }

        public bool Update(User user)
        {
            try
            {
                return _userDAL.Update(user);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region .: Not Used :.
        public IEnumerator<User> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}
