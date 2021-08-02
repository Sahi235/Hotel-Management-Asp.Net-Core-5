using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class ApplicationUserRole : IdentityUserRole<string>
    {
        public override string RoleId { get; set; }
        public override string UserId { get; set; }
        public ApplicationUser User { get; set; }
        public ApplicationRole Role { get; set; }
    }
}
