using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace DAL
{
    public class PassageDAL : IRepresentable<Model.Passage>
    {
        #region .: Attributes :.
        private readonly APSystemEntities _context;
        #endregion

        #region .: Constructors :.
        public PassageDAL()
        {
            _context = new APSystemEntities();
        }

        public PassageDAL(APSystemEntities context)
        {
            _context = context;
        }
        #endregion

        #region  .: Public Methods :.
        /// <summary>
        /// Método para atualizar uma passagem
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean Update(Model.Passage value)
        {
            try
            {
                Passage p = _context.Passages.Find(value.Number);
                p.Number = value.Number;
                p.ArrivalDate = value.ArrivalDate;
                p.DepartureDate = value.DepartureDate;
                p.IdUser = value.IdUser;
                p.Type = value.Type;

                _context.Passages.Attach(p);
                _context.Entry(p).State = EntityState.Modified;
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

        /// <summary>
        /// Método para inserir uma passagem
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean Insert(Model.Passage value)
        {
            try
            {
                Passage p = new Passage
                {
                    ArrivalDate = value.ArrivalDate,
                    DepartureDate = value.DepartureDate,
                    IdUser = value.IdUser,
                    Number = value.Number,
                    Type = value.Type,
                };

                _context.Passages.Add(p);
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

        /// <summary>
        /// Método para listar uma ou mais passagens
        /// </summary>
        /// <param name="condition"></param>
        /// <returns></returns>
        public List<Model.Passage> SelectByCondition(string condition)
        {
            try
            {
                List<Model.Passage> passages = new List<Model.Passage>();

                foreach (Passage passage in _context.Passages.SqlQuery(condition))
                {
                    Model.Passage p = new Model.Passage
                    {
                        ArrivalDate = passage.ArrivalDate,
                        DepartureDate = passage.DepartureDate,
                        Id = passage.Id,
                        IdUser = (int)passage.IdUser,
                        Number = passage.Number,
                        Type = passage.Type
                    };

                    passages.Add(p);
                }

                return passages;
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

        /// <summary>
        /// Método para remover uma passagem
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public Boolean Remove(Model.Passage value)
        {
            try
            {
                Passage p = _context.Passages.Find(value.Number);

                _context.Passages.Remove(p);

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

        /// <summary>
        /// Método para listar todas as passagens
        /// </summary>
        /// <returns></returns>
        public List<Model.Passage> SelectAll()
        {
            try
            {
                List<Model.Passage> passages = new List<Model.Passage>();

                foreach (Passage passage in _context.Passages)
                {
                    Model.Passage p = new Model.Passage
                    {
                        ArrivalDate = passage.ArrivalDate,
                        DepartureDate = passage.DepartureDate,
                        Id = passage.Id,
                        IdUser = (int)passage.IdUser,
                        Number = passage.Number,
                        Type = passage.Type
                    };

                    passages.Add(p);
                }

                return passages;
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
        #endregion

        #region .: Not Used :.
        #region .: IEnumerable<Passage> Members :.

        public IEnumerator<Model.Passage> GetEnumerator()
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
