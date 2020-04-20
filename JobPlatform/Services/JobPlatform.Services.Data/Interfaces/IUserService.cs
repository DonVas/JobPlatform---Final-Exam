namespace JobPlatform.Services.Data.Interfaces
{
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;

    using JobPlatform.Web.ViewModels.Administration.Dashboard;

    public interface IUserService
    {
        IEnumerable<T> GetAllUsers<T>();

        IEnumerable<T> GetAllRoles<T>();

        Task<IEnumerable<UserViewModel>> GetAllUsersAsync();

        int GetAllUsersCount();
    }
}
