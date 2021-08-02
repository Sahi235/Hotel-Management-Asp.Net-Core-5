using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Text;

namespace DataAccess.RequestFeatures
{
    public interface IDataShaping<in T>
    {
        ExpandoObject ShapeData(T entity, string filedNames);
        IEnumerable<ExpandoObject> ShapeData(IEnumerable<T> entities, string filedNames);
    }
}
