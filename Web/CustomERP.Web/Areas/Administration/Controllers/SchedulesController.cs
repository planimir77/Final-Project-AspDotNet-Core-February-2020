namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Threading.Tasks;

    using CustomERP.Common;
    using CustomERP.Data.Models;
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.Schedules;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class SchedulesController : AdministrationController
    {
        private readonly ISchedulesService schedulesService;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IScheduleDaysService scheduleDaysService;

        public SchedulesController(
            ISchedulesService schedulesService, UserManager<ApplicationUser> userManager, IScheduleDaysService scheduleDaysService)
        {
            this.schedulesService = schedulesService;
            this.userManager = userManager;
            this.scheduleDaysService = scheduleDaysService;
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

            return this.View(schedule);
        }

        // GET: Administration/Schedules/Create
        public IActionResult Create()
        {
            return this.View();
        }

        // POST: Administration/Schedules/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleCreateViewModel inputModel)
        {
            if (this.ScheduleExists<ScheduleCreateViewModel>(inputModel.Name, null))
            {
                this.TempData["Message"] = GlobalConstants.Messages.AlreadyExist;
                return this.View(inputModel);
            }

            var name = inputModel.Name;
            var numberOfDays = inputModel.NumberOfDays;

            if (this.ModelState.IsValid)
            {
                await this.schedulesService.CreateAsync(name, numberOfDays, this.Creator());

                return this.RedirectToAction("Index");
            }

            return this.View(inputModel);
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

            return this.View(schedule);
        }

        // POST: Administration/Schedules/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScheduleEditViewModel model)
        {
            var scheduleId = model.Id;
            var scheduleName = model.Name;
            if (this.ModelState.IsValid)
            {
                if (this.ScheduleExists<ScheduleCreateViewModel>(scheduleName, scheduleId))
                {
                    this.TempData["Message"] = GlobalConstants.Messages.AlreadyExist;
                    return this.View(model);
                }
                else if (model.NumberOfDays < this.ScheduleDaysCount(scheduleId))
                {
                    this.TempData["Message"] = GlobalConstants.Messages.InvalidOperation;
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
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.schedulesService.Delete(id, this.Creator());

            return this.RedirectToAction("Index");
        }

        private bool ScheduleExists<T>(string name, int? id)
        {
            return this.schedulesService.AnyByName<T>(name, id);
        }

        private string Creator()
        {
            return this.userManager.GetUserAsync(this.User).Result.FullName;
        }

        private int ScheduleDaysCount(int scheduleId)
        {
            var scheduleDaysCount = this.scheduleDaysService
                .GetDaysCountByScheduleId(scheduleId);
            return scheduleDaysCount;
        }
    }
}
