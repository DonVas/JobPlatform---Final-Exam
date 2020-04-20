// ReSharper disable VirtualMemberCallInConstructor

using JobPlatform.Data.Models.Enums;

namespace JobPlatform.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using JobPlatform.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Claims = new HashSet<ApplicationUserClaim>();
            this.Logins = new HashSet<ApplicationUserLogin>();
            this.Tokens = new HashSet<ApplicationUserToken>();
            this.UserRoles = new HashSet<ApplicationUserRole>();
        }

        [MinLength(2)]
        [MaxLength(20)]
        public virtual string FirstName { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public virtual string MiddleName { get; set; }

        [MinLength(2)]
        [MaxLength(20)]
        public virtual string FamilyName { get; set; }

        [Url]
        public string ProfilePicture { get; set; }

        [DataType(DataType.Date)]
        public DateTime Birthdate { get; set; }

        public Gender Gender { get; set; } = Gender.Unknown;

        // Audit info
        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public virtual ICollection<File> UserFiles { get; set; } = new HashSet<File>();

        public virtual ICollection<ApplicationUserClaim> Claims { get; set; }

        public virtual ICollection<ApplicationUserLogin> Logins { get; set; }

        public virtual ICollection<ApplicationUserToken> Tokens { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
    }
}
