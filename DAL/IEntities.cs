using System;
using System.Collections.Generic;

namespace DAL
{
    /// <summary>
    /// Interface para representar as Entidades
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IEntities<T> : IEnumerable<T>
    {
        Boolean Insert(T value);
        List<T> SelectByCondition(string condition);
        Boolean Remove(T value);
        List<T> SelectAll();
        Boolean Update(T value);
    }
}
