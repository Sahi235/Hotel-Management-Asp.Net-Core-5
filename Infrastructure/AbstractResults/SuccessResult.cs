using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.AbstractResults
{
    public class SuccessResult<T> : ISuccessResult<T>
    where T : class
    {
        public T Result { get; set; }
    }
}
