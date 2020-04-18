using System.ComponentModel.DataAnnotations;

namespace JobPlatform.Web.ViewModels.Administration.Dashboard.Users
{
    using System;
    using System.Globalization;
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

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public DateTime? DeletedOn { get; set; }

        public DateTimeOffset? LockoutEnd { get; set; }

        public bool IsDeleted { get; set; }

        public bool TwoFactorEnabled { get; set; }

        public bool PhoneNumberConfirmed { get; set; }

        public bool EmailConfirmed { get; set; }

        public bool LockoutEnabled { get; set; }

        public int AccessFailedCount { get; set; }
    }
}
