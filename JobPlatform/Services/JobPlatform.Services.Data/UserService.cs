namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using JobPlatform.Data.Common.Repositories;
    using JobPlatform.Data.Models;
    using JobPlatform.Services.Mapping;
    using JobPlatform.Web.ViewModels.Administration.Dashboard;
    using Microsoft.AspNetCore.Identity;

    public class UserService : IUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> userRepository;
        private readonly IDeletableEntityRepository<ApplicationRole> roleRepository;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RoleManager<ApplicationRole> roleManager;

        public UserService(
            IDeletableEntityRepository<ApplicationUser> deletableUserRepository,
            IDeletableEntityRepository<ApplicationRole> deletableRoleRepository,
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager)
        {
            this.userRepository = deletableUserRepository;
            this.roleRepository = deletableRoleRepository;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }

        public IEnumerable<T> GetAllRoles<T>()
        {
            return this.roleRepository.All().OrderByDescending(x => x.Name.Length).To<T>().ToList();
        }

        public IEnumerable<T> GetAllUsers<T>()
        {
            return this.userRepository.All().To<T>().ToList();
        }

        public async Task<IEnumerable<UserViewModel>> GetAllUsersAsync()
        {
            var users = this.GetAllUsers<UserViewModel>().OrderBy(u => u.UserName);

            var roles = this.roleRepository.All().OrderByDescending(r => r.Name).ToList();

            foreach (var user in users)
            {
                var appUser = this.userRepository.All().FirstOrDefault(u => u.Id == user.Id);
                user.RolesName = await this.userManager.GetRolesAsync(appUser);
            }

            return users;
        }

        public int GetAllUsersCount()
        {
            return this.userRepository.All().Count();
        }
    }
}
