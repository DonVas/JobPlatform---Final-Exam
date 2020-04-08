namespace JobPlatform.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName => this.FirstName + " " + this.MiddleName + " " + this.FamilyName;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public string ProfilePicture { get; set; }

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public ICollection<IdentityUserRole<string>> Roles { get; set; }

        public ICollection<RolesViewModel> RolesName { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<IdentityUser, UserViewModel>().ForMember(
                m => m.Id,
                opt => opt.MapFrom(u => u.Id));
        }
    }
}
