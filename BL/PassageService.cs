using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace BL
{
    public class PassageService
    {
        private readonly DAL.PassageDAL _passageDAL;

        public PassageService()
        {
            _passageDAL = new DAL.PassageDAL();
        }

        public PassageService(DAL.PassageDAL context)
        {
            _passageDAL = context;
        }

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
    }
}
