using System;
using System.Collections.Generic;

namespace DAL
{
    interface IEntities<T> : IEnumerable<T>
    {
        Boolean Insert(T value);
        List<T> SelectByCondition(string condition);
        Boolean Remove(T value);
        List<T> SelectAll();
        Boolean Update(T value);
    }
}
