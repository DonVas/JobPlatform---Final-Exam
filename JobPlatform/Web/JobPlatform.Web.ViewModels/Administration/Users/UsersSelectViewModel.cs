namespace JobPlatform.Web.ViewModels.Administration.Users
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using AutoMapper;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;
    using JobPlatform.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Identity;

    public class UsersSelectViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public UsersSelectViewModel()
        {
            //this.Roles = new List<ApplicationUserRole>();
        }

        public string Id { get; set; }

        public string UserName { get; set; }

        public string FullName => this.FirstName + " " + this.MiddleName + " " + this.FamilyName;

        public string FirstName { get; set; }

        public string MiddleName { get; set; }

        public string FamilyName { get; set; }

        public List<RolesViewModel> Roles { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
        configuration.CreateMap<IdentityUser, UserViewModel>().ForMember(
            m => m.Id,
            opt => opt.MapFrom(u => u.Id));
        }
    }
}
