using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class PassageDAL
    {
        private readonly APSystemEntities _context;

        public PassageDAL()
        {
            _context = new APSystemEntities();
        }

        public PassageDAL(APSystemEntities context)
        {
            _context = context;
        }

        public Boolean Insert(Model.Passage passage)
        {
            return false;
        }

        public Boolean Remove(Model.Passage passage)
        {
            return false;
        }

        public List<Model.Passage> SelectAll()
        {
            return null;
        }

        public Model.Passage SelectByCondition(string condition)
        {
            return null;
        }
    }
}
