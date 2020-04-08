namespace JobPlatform.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using JobPlatform.Services.Data;
    using JobPlatform.Web.Controllers;
    using JobPlatform.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdministrationController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Users()
        {
            var viewModel = new UsersViewModel();

            viewModel.Users = this.userService.GetAllUsers();
            viewModel.Roles = this.userService.GetAllRoles<RolesViewModel>();

            return this.View(viewModel);
        }
    }
}
