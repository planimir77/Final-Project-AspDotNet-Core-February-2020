namespace CustomERP.Web.ViewModels.Administration.Dashboard
{
    using System.ComponentModel.DataAnnotations;

    public class IndexViewModel
    {
        [Display(Name = "Employees")]
        public int EmployeesCount { get; set; }

        [Display(Name = "Sections")]
        public int SectionsCount { get; set; }

        [Display(Name = "Companies")]
        public int CompaniesCount { get; set; }

        [Display(Name = "Teams")]
        public int TeamsCount { get; set; }

        [Display(Name = "Schedules")]
        public int SchedulesCount { get; set; }
    }
}
