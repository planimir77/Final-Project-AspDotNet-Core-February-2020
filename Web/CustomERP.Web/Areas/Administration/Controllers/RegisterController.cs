namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Web.ViewModels.Administration.Register;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    public class RegisterController : AdministrationController
    {
        private readonly IDeletableEntityRepository<ApplicationUser> repository;
        private readonly SignInManager<ApplicationUser> signInManager;

        public RegisterController(IDeletableEntityRepository<ApplicationUser> repository, SignInManager<ApplicationUser> signInManager)
        {
            this.repository = repository;
            this.signInManager = signInManager;
        }

        public IActionResult Index()
        {
            var viewModel = new UserInputViewModel();
            return this.View(viewModel);
        }

        public async Task<IActionResult> CreateUser(UserInputViewModel viewModel)
        {
            var user = this.repository.All().FirstOrDefault(u => u.FullName == viewModel.FullName);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    FullName = viewModel.FullName,
                    Position = viewModel.Position,
                    CreatedFrom = this.User.Identities.FirstOrDefault()?.Name,
                };
                var y = this.User.Identities;

                await this.repository.AddAsync(user);
                await this.repository.SaveChangesAsync();
                return this.Redirect("/Administration/Dashboard/Index");
            }

            return this.Content("Username already exist");
        }
    }
}
