using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.AbstractResults
{
    public class FailureResult : IFailureResult
    {
        public string Message { get; set; }
    }
}
