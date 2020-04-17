namespace JobPlatform.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;

    public class UsersViewModel
    {
        public int CurrentPage { get; set; }

        public int PagesCount { get; set; }

        public IEnumerable<UserViewModel> Users { get; set; }

        public IEnumerable<RoleViewModel> Roles { get; set; }
    }
}
