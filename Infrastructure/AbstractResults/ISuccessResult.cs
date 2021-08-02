using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.AbstractResults
{
    public interface ISuccessResult<T> where T : class
    {
        public T Result { get; set; }
    }
}
