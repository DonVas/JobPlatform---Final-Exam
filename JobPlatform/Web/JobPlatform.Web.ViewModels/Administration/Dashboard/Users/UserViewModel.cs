namespace JobPlatform.Web.ViewModels.Administration.Dashboard
{
    using System.Collections.Generic;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class UserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName => this.FirstName + " " + this.MiddleName + " " + this.FamilyName;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public ICollection<string> RolesName { get; set; } = new HashSet<string>();
    }
}
