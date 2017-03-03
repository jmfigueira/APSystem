using System;
using System.Collections.Generic;

namespace BL
{
    interface IService<T> : IEnumerable<T>
    {
        Boolean Create(T value);
        Boolean Remove(string value);
        List<T> Select(string condition, string value);
        Boolean Update(T user);
    }
}
