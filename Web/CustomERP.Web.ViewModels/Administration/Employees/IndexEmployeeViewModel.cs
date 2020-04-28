namespace CustomERP.Web.ViewModels.Administration.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class IndexEmployeeViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Display(Name = "Employee Name")]
        public string FullName { get; set; }

        [Display(Name = "Position")]
        public string Position { get; set; }

        [Display(Name = "Team")]
        public string TeamName { get; set; }

        [Display(Name = "Section")]
        public string SectionName { get; set; }

        [Display(Name = "Company")]
        public string CompanyName { get; set; }

        [Display(Name = "Manager")]
        public string ApplicationUserManagerFullName { get; set; }

        [Display(Name = "From Date")]
        [DataType(DataType.Date)]
        public DateTime CreatedOn { get; set; }
    }
}
