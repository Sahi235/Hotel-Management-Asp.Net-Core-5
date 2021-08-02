using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class EmployeeImage : Image
    {
        public ApplicationUser User { get; set; }
        public string UserId { get; set; }
    }
}
