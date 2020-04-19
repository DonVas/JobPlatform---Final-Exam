namespace JobPlatform.Data.Models
{
    using Microsoft.AspNetCore.Identity;

    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}
