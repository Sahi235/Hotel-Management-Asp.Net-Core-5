using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.AbstractResults
{
    public interface IFailureResult
    {
        public string Message { get; set; }
    }
}
