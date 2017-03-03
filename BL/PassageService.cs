using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BL
{
    public class PassageService : IService<Passage>
    {
        #region .: Attributes :.
        private readonly DAL.PassageDAL _passageDAL;
        #endregion

        #region .: Constructors :.
        public PassageService()
        {
            _passageDAL = new DAL.PassageDAL();
        }

        public PassageService(DAL.PassageDAL context)
        {
            _passageDAL = context;
        }
        #endregion

        #region .: Public Methods :.
        public List<Passage> Select(string condition, string value)
        {
            try
            {
                if (!String.IsNullOrEmpty(condition) || !String.IsNullOrEmpty(value))
                {
                    string query = string.Format("WHERE [{0}] = {1}", condition, value);

                    return _passageDAL.SelectByCondition(query);
                }

                return _passageDAL.SelectAll();
            }
            catch
            {
                return null;
            }
        }

        public bool Create(Passage value)
        {
            try
            {
                var result = Select("Number", value.Number);
                Passage passage = result.Count > 0 ? result.First() : null;

                if (passage == null)
                {
                    passage = new Passage()
                    {
                        ArrivalDate = value.ArrivalDate,
                        DepartureDate = value.DepartureDate,
                        Number = value.Number,
                        Type = value.Type
                    };
                    return _passageDAL.Insert(passage);
                }
                return false;
            }
            catch
            {
                return false;
            }
        }


        //TODO: Testar esse método
        public bool Remove(string number)
        {
            try
            {
                Passage passage = Select("Number", number).First();

                return _passageDAL.Remove(passage);
            }
            catch
            {
                return false;
            }
        }

        public bool Update(Passage passage)
        {
            try
            {
                return _passageDAL.Update(passage);
            }
            catch
            {
                return false;
            }
        }
        #endregion

        #region .: Not Used :.
        public IEnumerator<Passage> GetEnumerator()
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
