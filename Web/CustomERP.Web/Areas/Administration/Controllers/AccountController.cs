namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.Register;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class AccountController : AdministrationController
    {
        private readonly IApplicationUserService userService;
        private readonly SignInManager<ApplicationUser> signInManager;

        public AccountController(IApplicationUserService userService, SignInManager<ApplicationUser> signInManager)
        {
            this.userService = userService;
            this.signInManager = signInManager;
        }

        // GET: /Account/Index
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        // GET: /Account/Register
        public IActionResult Register()
        {
            var viewModel = new UserInputViewModel();
            return this.View(viewModel);
        }

        // POST:  /Account/Register
        public async Task<IActionResult> Register(UserInputViewModel viewModel)
        {
            var inputViewModels = viewModel;//this.entityService.GetAll<UserInputViewModel>();
            if (inputViewModels == null)
            {

                var user = new ApplicationUser
                {
                    FullName = viewModel.FullName,
                    Position = viewModel.Position,
                    CreatedFrom = this.User.Identities.FirstOrDefault()?.Name,
                };
                var y = this.User.Identities;

                //await this.repository.AddAsync(user);
                //await this.repository.SaveChangesAsync();
                return this.Redirect("/Administration/Dashboard/Index");
            }

            return this.Content("Username already exist");
        }
    }
}
