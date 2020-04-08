namespace JobPlatform.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class UsersViewModel
    {
        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<RolesViewModel> Roles { get; set; }
    }
}
