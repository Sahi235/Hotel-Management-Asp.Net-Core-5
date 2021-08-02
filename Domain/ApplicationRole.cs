using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationRole : IdentityRole
    {
        public virtual ICollection<ApplicationUserRole> Users { get; set; }
    }
}
