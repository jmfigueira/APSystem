﻿using Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BL
{
    public class UserService : IService<User>
    {
        #region .: Attributes :.
        private readonly DAL.UserDAL _userDAL;
        #endregion

        #region .: Constructors :.
        /// <summary>
        /// Construtor padrão
        /// </summary>
        public UserService()
        {
            _userDAL = new DAL.UserDAL();
        }

        /// <summary>
        /// Construtor que utiliza um contexto já existente
        /// </summary>
        /// <param name="context"></param>
        public UserService(DAL.UserDAL context)
        {
            _userDAL = context;
        }
        #endregion

        #region .: Public Methods :.

        /// <summary>
        /// Cria um usuário
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Remove um usuário conforme seu Login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Buscar dados no banco, com ou sem uma condição
        /// </summary>
        /// <param name="condition"></param>
        /// <param name="value"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Atualiza um usuário no banco
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
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
