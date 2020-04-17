namespace JobPlatform.Web.ViewModels.Administration.Dashboard.Users
{
    using System;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;


    public class SelectedUserViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }

        public string UserName { get; set; }

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string CreatedOn { get; set; }

        public string ModifiedOn { get; set; }

        public string DeletedOn { get; set; }

        public string LockoutEnd { get; set; }

        public bool IsDeleted { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
    }
}
