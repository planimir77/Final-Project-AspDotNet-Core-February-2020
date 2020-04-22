namespace CustomERP.Web.ViewModels.Administration.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Services.Mapping;

    public class IndexViewModel
    {
        [Display(Name = "Employees")]
        public int EmployeesCount { get; set; }

        [Display(Name = "Sections")]
        public int SectionsCount { get; set; }

        [Display(Name = "Companies")]
        public int CompaniesCount { get; set; }

        [Display(Name = "Teams")]
        public int ShiftsCount { get; set; }

        [Display(Name = "Schedules")]
        public int SchedulesCount { get; set; }
    }
}
