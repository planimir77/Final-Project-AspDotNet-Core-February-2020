namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.Accounts;
    using CustomERP.Web.ViewModels.Shared;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : AdministrationController
    {
        private readonly IApplicationUserService userService;
        private readonly ICompaniesService companiesService;

        public AccountController(
            IApplicationUserService userService,
            ICompaniesService companiesService)
        {
            this.userService = userService;
            this.companiesService = companiesService;
        }

        // GET: /Account/Index
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

        // GET: /Account/RegisterEmployee
        public IActionResult RegisterEmployee()
        {
            var company = this.companiesService.GetAll<CompanyDropDownViewModel>();
            var viewModel = new EmployeeInputViewModel
            {
                Companies = company,
            };
            return this.View(viewModel);
        }

        // POST:  /Account/RegisterEmployee
        [HttpPost]
        public async Task<IActionResult> RegisterEmployee(EmployeeInputViewModel inputModel)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View();
            }

            inputModel.CreatedFrom = this.User.Identities.FirstOrDefault()?.Name;

            var existingЕmployee = this.userService.GetAll<EmployeeInputViewModel>()
                .FirstOrDefault(u => u.FullName == inputModel.FullName);

            if (existingЕmployee == null)
            {
                var id = await this.userService.RegisterAsync(inputModel);

                // TODO Return Details(id)
                return this.Redirect("/Administration/Account/Index");
            }

            // TODO Return existing user Details(id) with message
            return this.Content("Username  already exist");
        }
    }
}
