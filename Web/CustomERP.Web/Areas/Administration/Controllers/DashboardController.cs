namespace CustomERP.Web.Areas.Administration.Controllers
{
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.Dashboard;

    using Microsoft.AspNetCore.Mvc;

    public class DashboardController : AdministrationController
    {
        private readonly IApplicationUserService applicationUserService;
        private readonly ISchedulesService schedulesService;
        private readonly ICompaniesService companiesService;
        private readonly ISectionsService sectionsService;
        private readonly ITeamsService teamsService;

        public DashboardController(
            IApplicationUserService applicationUserService, ISchedulesService schedulesService, ICompaniesService companiesService, ISectionsService sectionsService, ITeamsService teamsService)
        {
            this.applicationUserService = applicationUserService;
            this.schedulesService = schedulesService;
            this.companiesService = companiesService;
            this.sectionsService = sectionsService;
            this.teamsService = teamsService;
        }

        public IActionResult Index()
        {
            var viewModel = new IndexViewModel
            {
                EmployeesCount = this.applicationUserService.GetCount(),
                SchedulesCount = this.schedulesService.GetCount(),
                CompaniesCount = this.companiesService.GetCount(),
                SectionsCount = this.sectionsService.GetCount(),
                ShiftsCount = this.teamsService.GetCount(),
            };

            return this.View(viewModel);
        }
    }
}
