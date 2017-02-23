using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    public class UserDAL : IRepresentable<Model.User>
    {
        #region .: Attributes :.
        private readonly APSystemEntities _context;
        #endregion

        #region .: Constructors :.
        /// <summary>
        /// Criação do contexto no construtor
        /// </summary>
        /// <param name="context"></param>
        public UserDAL()
        {
            _context = new APSystemEntities();
        }

        /// <summary>
        /// Utiliza um contexto existente
        /// </summary>
        /// <param name="context"></param>
        public UserDAL(APSystemEntities context)
        {
            _context = context;
        }
        #endregion

        #region .: Public Methods :.
        //TODO: testar
        /// <summary>
        /// Método para atualizar um usuário
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean Update(Model.User value)
        {
            try
            {
                User u = _context.Users.Find(value.Login);
                u.CPF = value.CPF;
                u.Password = value.Password;
                u.RG = value.RG;

                _context.Users.Attach(u);
                _context.Entry(u).State = EntityState.Modified;
                _context.SaveChanges();

                return true;
            }
            catch (Exception exception)
            {
                Log log = new Log
                {
                    Date = DateTime.Now,
                    Details = exception.Message,
                    Message = "An exception occurred in method Update"
                };

                _context.Logs.Add(log);
                _context.SaveChanges();

                throw;
            }
        }

        //TODO: testar
        /// <summary>
        /// Método para inserir um usuário no banco
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean Insert(Model.User value)
        {
            try
            {
                User u = new User
                {
                    CPF = value.CPF,
                    Login = value.Login,
                    Password = value.Password,
                    RG = value.RG
                };

                _context.Users.Add(u);
                _context.SaveChanges();

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
                _context.SaveChanges();

                throw;
            }
        }

        //TODO: testar
        /// <summary>
        /// Método para remover um usuário
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public Boolean Remove(Model.User value)
        {
            try
            {
                User u = _context.Users.Find(value.Login);

                _context.Users.Remove(u);
                _context.SaveChanges();

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
                _context.SaveChanges();

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

                foreach (User user in _context.Users)
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
                _context.SaveChanges();

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

                foreach (User user in _context.Users.SqlQuery(condition))
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
                    Message = "An exception occurred in method SelectByCondition"
                };

                _context.Logs.Add(log);
                _context.SaveChanges();

                throw;
            }
        }
        #endregion

        #region .: Not Used :.
        #region .: IEnumerable<User> Members :.

        public IEnumerator<Model.User> GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region .: IEnumerable Members :.

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        #endregion
        #endregion
    }
}
