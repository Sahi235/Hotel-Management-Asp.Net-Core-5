using System;
using System.Collections.Generic;
using System.Text;

namespace DataAccess.RequestFeatures
{
    public abstract class BaseRequestFeatures
    {
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}
