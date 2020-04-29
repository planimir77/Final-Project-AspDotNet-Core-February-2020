namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CustomERP.Common;
    using CustomERP.Data.Models;
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.Schedules;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.EntityFrameworkCore;

    public class SchedulesController : AdministrationController
    {
        private readonly ISchedulesService schedulesService;
        private readonly UserManager<ApplicationUser> userManager;

        public SchedulesController(ISchedulesService schedulesService, UserManager<ApplicationUser> userManager)
        {
            this.schedulesService = schedulesService;
            this.userManager = userManager;
        }

        // GET: Administration/Schedules
        public IActionResult Index()
        {
            var schedules = this.schedulesService.GetAll<SchedulesViewModel>();

            var viewModel = new SchedulesListViewModel
            {
                SchedulesViewModels = schedules,
            };

            return this.View(viewModel);
        }

        // GET: Administration/Schedules/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var schedule = this.schedulesService.GetById<SchedulesViewModel>(id);
            if (schedule == null)
            {
                return this.NotFound();
            }

            return View(schedule);
        }

        // GET: Administration/Schedules/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Administration/Schedules/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleCreateViewModel inputModel)
        {

            if (this.ScheduleExists<ScheduleCreateViewModel>(inputModel.Name))
            {
                this.TempData["Message"] = GlobalConstants.Messages.AlreadyExist;
                return View(inputModel);
            }

            var name = inputModel.Name;
            var numberOfDays = inputModel.NumberOfDays;

            if (this.ModelState.IsValid)
            {
                await this.schedulesService.CreateAsync(name, numberOfDays, this.Creator());

                return this.RedirectToAction("Index");
            }

            return View(inputModel);
        }

        // GET: Administration/Schedules/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var schedule = this.schedulesService
                .GetById<ScheduleEditViewModel>(id);

            if (schedule == null)
            {
                return this.NotFound();
            }

            return View(schedule);
        }

        // POST: Administration/Schedules/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScheduleEditViewModel model)
        {
            if (this.ModelState.IsValid)
            {
                if (this.ScheduleExists<ScheduleCreateViewModel>(model.Name))
                {
                    this.TempData["Message"] = GlobalConstants.Messages.AlreadyExist;
                    return this.View(model);
                }

                await this.schedulesService.Update(
                    model.Id, model.Name, model.NumberOfDays, this.Creator());
                return this.RedirectToAction("Index");
            }

            return this.View(model);
        }

        // GET: Administration/Schedules/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var schedule = this.schedulesService.GetById<ScheduleDeleteViewModel>(id);
            if (schedule == null)
            {
                return this.NotFound();
            }

            return this.View(schedule);
        }

        // POST: Administration/Schedules/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            this.schedulesService.Delete(id);

            return this.RedirectToAction("Index");
        }

        private bool ScheduleExists<T>(string name)
        {
            return this.schedulesService.AnyByName<T>(name);
        }

        private string Creator()
        {
            return this.userManager.GetUserAsync(this.User).Result.FullName;
        }
    }
}
