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
    using JobPlatform.Web.ViewModels.Administration.Dashboard.Users;
    using Microsoft.AspNetCore.Mvc;

    public class UsersController : AdministrationController
    {
        private readonly IUserService userService;

        public UsersController(IUserService userService)
        {
            this.userService = userService;
        }

        public async Task<IActionResult> UsersAsync()
        {
            var viewModel = new UsersViewModel();

            viewModel.Users = await this.userService.GetAllUsersAsync();
            viewModel.Roles = this.userService.GetAllRoles<RoleViewModel>();

            if (viewModel.Users == null && viewModel.Roles == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        public IActionResult UserById(string id)
        {
            var viewModel = this.userService.GetAllUsers<SelectedUserViewModel>().FirstOrDefault(x => x.Id == id);
            if (viewModel == null)
            {
                return this.NotFound();
            }

            return this.View(viewModel);
        }

        [HttpPost]
        public IActionResult Search()
        {
            return this.View();
        }
    }
}
