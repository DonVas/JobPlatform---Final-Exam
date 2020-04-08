namespace JobPlatform.Web.Areas.Administration.Controllers
{
    using JobPlatform.Common;
    using JobPlatform.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.Administrator)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
