// ReSharper disable VirtualMemberCallInConstructor

namespace CustomERP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;
    using Microsoft.AspNetCore.Identity;

    public class ApplicationUser : IdentityUser, IAuditInfo, IDeletableEntity
    {
        public ApplicationUser()
        {
            this.Id = Guid.NewGuid().ToString();
            this.Roles = new HashSet<IdentityUserRole<string>>();
            this.Claims = new HashSet<IdentityUserClaim<string>>();
            this.Logins = new HashSet<IdentityUserLogin<string>>();
            this.ApplicationUserManagers = new HashSet<ApplicationUser>();
        }

        [MinLength(8)]
        [RegularExpression(
            "^([A-Z][a-z]+\\s[A-Z][a-z]+\\s[A-Z][a-z]+|[А-Я][а-я]+\\s[А-Я][а-я]+\\s[А-Я][а-я]+)")]
        public string FullName { get; set; }

        [Required]
        public string Position { get; set; }

        // Audit info
        public string CreatedFrom { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

#nullable enable
        public string? ModifiedFrom { get; set; }

        // Deletable entity
        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedFrom { get; set; }

        // Relations
        public int? AddressId { get; set; }

        public virtual Address UserAddress { get; set; }

        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }

        public string? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public string? ManagerId { get; set; }

        public virtual ApplicationUser ApplicationUserManager { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUserManagers { get; set; }

        public virtual ICollection<IdentityUserRole<string>> Roles { get; set; }

        public virtual ICollection<IdentityUserClaim<string>> Claims { get; set; }

        public virtual ICollection<IdentityUserLogin<string>> Logins { get; set; }
    }
}
