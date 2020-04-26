namespace JobPlatform.Web.Areas.User.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using JobPlatform.Common;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Data.Interfaces;
    using JobPlatform.Web.Controllers;
    using JobPlatform.Web.ViewModels.Companies;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Http;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.UserRole)]
    [Area("User")]
    public class CompaniesController : BaseController
    {
            private readonly IFileService fileService;
            private readonly ICompanyService companyService;
            private readonly UserManager<ApplicationUser> userManager;

            public CompaniesController(
                IFileService fileService,
                ICompanyService companyService,
                UserManager<ApplicationUser> userManager)
            {
                this.fileService = fileService;
                this.companyService = companyService;
                this.userManager = userManager;
            }

            [HttpGet]
            public IActionResult Index()
            {
                var viewModel = this.companyService.GetAllCompanies<CompanySimpleViewModel>();

                return this.View(viewModel);
            }

            public IActionResult Details(string id)
            {
                var viewModel = this.companyService.CompanyById<CompanyDetailsViewModel>(id);

                return this.View(viewModel);
            }

        }
}
