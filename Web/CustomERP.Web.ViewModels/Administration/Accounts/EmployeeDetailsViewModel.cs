namespace CustomERP.Web.ViewModels.Administration.Accounts
{
    using System;
    using System.Collections.Generic;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;
    using Microsoft.AspNetCore.Identity;

    public class EmployeeDetailsViewModel : IMapFrom<ApplicationUser>
    {
        public string FullName { get; set; }

        public string Position { get; set; }

        public int? ShiftId { get; set; }

        public virtual Shift Shift { get; set; }

        // Audit info
        public string CreatedFrom { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string? ModifiedFrom { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        public string? DeletedFrom { get; set; }

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
    }
}
