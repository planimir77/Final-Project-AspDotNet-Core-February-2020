// ReSharper disable VirtualMemberCallInConstructor

namespace CustomERP.Data.Models
{
    using System;

    using CustomERP.Data.Common.Models;

    using Microsoft.AspNetCore.Identity;

    public class ApplicationRole : IdentityRole, IAuditInfo, IDeletableEntity
    {
        public ApplicationRole()
            : this(null)
        {
        }

        public ApplicationRole(string name)
            : base(name)
        {
            this.Id = Guid.NewGuid().ToString();
        }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string CreatedFrom { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

#nullable enable
        public string? ModifiedFrom { get; set; }

        public string? DeletedFrom { get; set; }
    }
}
