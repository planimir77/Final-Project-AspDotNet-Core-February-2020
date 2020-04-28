namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.Employees;
    using CustomERP.Web.ViewModels.Shared;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class EmployeesController : AdministrationController
    {
        private const string EmployeeExist = "Тhe employee already exists in the database";
        private const string NotBeenSaved = " not been saved, try again!";
        private const string SuccessfullyUpdated = "Successfully updated";
        private const string SuccessfullyDelete = "Successfully delete ";

        private readonly IApplicationUserService userService;
        private readonly ICompaniesService companiesService;
        private readonly ISectionsService sectionsService;
        private readonly ITeamsService teamService;
        private readonly UserManager<ApplicationUser> userManager;

        public EmployeesController(
            IApplicationUserService userService,
            ICompaniesService companiesService,
            ISectionsService sectionsService,
            ITeamsService teamService,
            UserManager<ApplicationUser> userManager)
        {
            this.userService = userService;
            this.companiesService = companiesService;
            this.sectionsService = sectionsService;
            this.teamService = teamService;
            this.userManager = userManager;
        }

        // GET: Administration/Employees/Index
        [HttpGet]
        public IActionResult Index()
        {
            var users = this.userService.GetAll<IndexEmployeeViewModel>();

            var viewModel = new IndexViewModel
            {
                Users = users,
            };

            return this.View(viewModel);
        }

        // GET: Administration/Employees/Details/id
        public IActionResult Details(string id, string message = "")
        {
            if (string.IsNullOrWhiteSpace(id))
            {
                return this.NotFound();
            }

            var viewModel = this.userService.GetById<EmployeeDetailsViewModel>(id);
            var user = this.userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = this.userManager.GetRolesAsync(user).Result.Select(x => x).ToList();
            var rolesAsString = string.Join(", ", roles);
            viewModel.Roles = rolesAsString;
            viewModel.CreatedOn = viewModel.CreatedOn.ToLocalTime();
            if (viewModel.ModifiedOn != null)
            {
                viewModel.ModifiedOn = viewModel.ModifiedOn.Value.ToLocalTime();
            }

            this.ViewData["Message"] = message;

            return this.View(viewModel);
        }

        // GET: Administration/Employees/RegisterEmployee
        public IActionResult Register()
        {
            var companies =
                this.companiesService
                .GetAll<CompanyDropDownViewModel>()
                .Prepend(new CompanyDropDownViewModel { Id = string.Empty, Name = string.Empty });

            var sections =
                this.sectionsService
                .GetAll<SectionDropDownViewModel>()
                .Prepend(new SectionDropDownViewModel() { Id = null, Name = string.Empty });

            var teams =
                this.teamService
                .GetAll<TeamDropDownViewModel>()
                .Prepend(new TeamDropDownViewModel() { Id = null, Name = string.Empty });

            var users =
                this.userService
                .GetAll<ApplicationUserDropDownViewModel>()
                .Prepend(new ApplicationUserDropDownViewModel { Id = string.Empty, FullName = string.Empty });

            var viewModel = new EmployeeRegisterViewModel
            {
                Companies = companies,
                Sections = sections,
                Teams = teams,
                ApplicationUsers = users,
            };

            return this.View(viewModel);
        }

        // POST:  Administration/Employees/RegisterEmployee
        [HttpPost]

        public async Task<IActionResult> Register(EmployeeRegisterViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            inputModel.CreatedFrom = this.userManager.GetUserAsync(this.User).Result.FullName;

            var existingЕmployeeId = this.userService.GetIdByFullName(inputModel.FullName);

            if (existingЕmployeeId == null)
            {
                var userId = await this.userService.RegisterAsync(inputModel);

                return this.RedirectToAction(nameof(this.Details), new { id = userId });
            }

            const string messageContent = EmployeeExist;

            return this.RedirectToAction("Details", "Employees", new { id = existingЕmployeeId, message = messageContent });
        }

        // GET: Administration/Employees/Edit/id
        public IActionResult Edit(string id)
        {
            var companies =
                this.companiesService
                    .GetAll<CompanyDropDownViewModel>();

            var sections =
                this.sectionsService
                    .GetAll<SectionDropDownViewModel>();

            var teams =
                this.teamService
                    .GetAll<TeamDropDownViewModel>();

            var users =
                this.userService
                    .GetAll<ApplicationUserDropDownViewModel>();

            var viewModel = this.userService.GetById<EmployeeEditViewModel>(id);

            viewModel.ApplicationUsers = users;
            viewModel.Companies = companies;
            viewModel.Sections = sections;
            viewModel.Teams = teams;

            return this.View(viewModel);
        }

        // Post: Administration/Employees/Edit/
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(EmployeeEditInputModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                this.ViewData["Message"] = NotBeenSaved;
                return this.Edit(inputModel.Id);
            }

            inputModel.ModifiedFrom = this.userManager.GetUserAsync(this.User).Result.FullName;

            var userId = await this.userService.Update(inputModel);

            var messageContent = SuccessfullyUpdated;

            return this.RedirectToAction("Details", "Employees", new { id = userId, message = messageContent });
        }

        // Get: Administration/Employees/Delete/id
        [HttpGet]
        public async Task<IActionResult> Delete(string id)
        {
            return await this.DeleteAsync(id);
        }

        // Post: Administration/Employees/DeleteAsync/id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAsync(string id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var admin = this.userManager.GetUserAsync(this.User).Result.FullName;
            var name = await this.userService.DeleteById(id, admin);

            this.TempData["MessageContent"] = SuccessfullyDelete + name;

            return this.RedirectToAction("Index", "Employees");
        }
    }
}
