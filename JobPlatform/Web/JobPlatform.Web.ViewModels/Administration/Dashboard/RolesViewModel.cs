namespace JobPlatform.Web.ViewModels.Administration.Dashboard
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class RolesViewModel : IMapFrom<ApplicationRole>
    {
        public RolesViewModel(string id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public string Id { get; set; }

        public string Name { get; set; }
    }
}
