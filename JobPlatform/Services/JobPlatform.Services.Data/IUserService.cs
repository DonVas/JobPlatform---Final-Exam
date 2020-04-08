namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using JobPlatform.Web.ViewModels.Administration.Dashboard;

    public interface IUserService
    {
        IEnumerable<T> GetAllUsers<T>();

        IEnumerable<T> GetAllRoles<T>();

        IEnumerable<UserViewModel> GetAllUsers();
    }
}
