using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUser : IdentityUser
    {
        public ICollection<ApplicationUserRole> Roles { get; set; }
        public EmployeeImage EmployeeImage { get; set; }
        public ICollection<EmployeePaymentHistory> EmployeePaymentHistories { get; set; } = new HashSet<EmployeePaymentHistory>();

    }
}
