namespace JobPlatform.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

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

        public IEnumerable<UserViewModel> GetAllUsers()
        {
            //int? take = null, int skip = 0
            //var query = this.userRepository.All()
            //    .OrderByDescending(x => x.UserName)
            //    .Skip(skip);

            //if (take.HasValue)
            //{
            //    query = query.Take(take.Value);
            //}

            //query.To<UserViewModel>().ToList();

            var users = this.GetAllUsers<UserViewModel>();
            var roles = this.roleRepository.All().ToList();
            var results = new List<UserViewModel>();

            foreach (var user in users)
            {
                    var userAdd = new UserViewModel
                    {
                        Id = user.Id,
                        CreatedOn = user.CreatedOn,
                        DeletedOn = user.DeletedOn,
                        FamilyName = user.FamilyName,
                        FirstName = user.FirstName,
                        IsDeleted = user.IsDeleted,
                        MiddleName = user.MiddleName,
                        ModifiedOn = user.ModifiedOn,
                        ProfilePicture = user.ProfilePicture,
                        UserName = user.UserName,
                        RolesName = new List<RolesViewModel>(),
                    };

                    foreach (var role in roles)
                    {
                        foreach (var userRole in user.Roles)
                        {
                            if (role.Id == userRole.RoleId)
                            {
                                var roleAdd = new RolesViewModel(role.Id, role.Name);
                                userAdd.RolesName.Add(roleAdd);
                            }
                        }
                    }

                    results.Add(userAdd);
            }

            return results;
        }
    }
}
