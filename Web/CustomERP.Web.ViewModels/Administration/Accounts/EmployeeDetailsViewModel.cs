using System.Collections.Generic;

namespace CustomERP.Web.ViewModels.Administration.Accounts
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class EmployeeDetailsViewModel : IMapFrom<ApplicationUser>
    {
        [Display(Name = "Name")]
        public string FullName { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Shift")]
        public string ShiftName { get; set; }

        [Display(Name = "Created")]
        public string CreatedFrom { get; set; }

        [Display(Name = "Created")]
        [DataType(DataType.DateTime)]
        public DateTime CreatedOn { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.Date)]
        public DateTime? ModifiedOn { get; set; }

        [Display(Name = "Modified")]
        public string ModifiedFrom { get; set; }

        [Display(Name = "Modified")]
        [DataType(DataType.Date)]
        public DateTime? DeletedOn { get; set; }

        [Display(Name = "Deleted")]
        public string DeletedFrom { get; set; }
        // TODO
        //public int? AddressId { get; set; }
        //
        //public virtual Address UserAddress { get; set; }

        [Display(Name = "Section")]
        public string SectionName { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Manager")]
        public string ApplicationUserManagerFullName { get; set; }

        [Display(Name = "Manager")]
        public IEnumerable<ManagerOfViewModel> ApplicationUserManagers { get; set; }

        [IgnoreMap]
        [Display(Name = "Roles")]
        public string Roles { get; set; }
    }
}
