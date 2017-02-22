using System;
using System.Collections.Generic;
using System.Linq;

namespace DAL
{
    public class UserDAL
    {
        #region .: Attributes :.
        private readonly APSystemEntities _context;
        #endregion

        #region .: Constructors :.
        public UserDAL()
        {
            _context = new APSystemEntities();
        }

        public UserDAL(APSystemEntities context)
        {
            _context = context;
        }
        #endregion

        #region .: Public Methods :.
        //TODO: testar
        /// <summary>
        /// Método para inserir um usuário no banco
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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

                _context.Users.Add(u);

                return true;
            }
            catch (Exception exception)
            {
                Log log = new Log
                {
                    Date = DateTime.Now,
                    Details = exception.Message,
                    Message = "An exception occurred in method Insert"
                };

                _context.Logs.Add(log);

                throw;
            }
        }

        //TODO: testar
        /// <summary>
        /// Método para remover um usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean Remove(Model.User user)
        {
            try
            {
                User u = _context.Users.Where(x => x.Login == user.Login).FirstOrDefault();

                _context.Users.Remove(u);

                return true;
            }
            catch (Exception exception)
            {
                Log log = new Log
                {
                    Date = DateTime.Now,
                    Details = exception.Message,
                    Message = "An exception occurred in method Remove"
                };

                _context.Logs.Add(log);

                throw;
            }
        }

        //TODO: testar
        /// <summary>
        /// Método para trazer todos os usuários do banco
        /// </summary>
        /// <returns></returns>
        public List<Model.User> SelectAll()
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                foreach (var user in _context.Users.ToList())
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
            catch (Exception exception)
            {
                Log log = new Log
                {
                    Date = DateTime.Now,
                    Details = exception.Message,
                    Message = "An exception occurred in method SelectAll"
                };

                _context.Logs.Add(log);

                throw;
            }
        }

        //TODO: testar
        /// <summary>
        /// Método para fazer um select nos usuário segundo uma condição
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Model.User> SelectByCondition(string condition)
        {
            try
            {
                List<Model.User> users = new List<Model.User>();

                foreach (var user in _context.Users.SqlQuery(condition))
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
            catch(Exception exception)
            {
                Log log = new Log
                {
                    Date = DateTime.Now,
                    Details = exception.Message,
                    Message = "An exception occurred in method SelectByCondition"
                };

                _context.Logs.Add(log);

                throw;
            }
        }
        #endregion
    }
}
