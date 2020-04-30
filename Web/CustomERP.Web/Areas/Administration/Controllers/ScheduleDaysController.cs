namespace CustomERP.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Models;
    using CustomERP.Services.Data;
    using CustomERP.Web.ViewModels.Administration.ScheduleDays;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;

    [Area("Administration")]
    public class ScheduleDaysController : AdministrationController
    {
        private readonly IScheduleDaysService scheduleDaysServices;
        private readonly ISchedulesService schedulesService;
        private readonly UserManager<ApplicationUser> userManager;

        public ScheduleDaysController(
            IScheduleDaysService scheduleDaysServices, ISchedulesService schedulesService, UserManager<ApplicationUser> userManager)
        {
            this.scheduleDaysServices = scheduleDaysServices;
            this.schedulesService = schedulesService;
            this.userManager = userManager;
        }

        // GET: Administration/ScheduleDays/5
        public IActionResult Index(int id)
        {
            if (this.ScheduleExists(id))
            {
                var scheduleDays = this.scheduleDaysServices
                    .GetAllByScheduleId<ScheduleDayViewModel>(id).ToList();

                var viewModel = new ScheduleDayListViewModel
                {
                    ScheduleId = id,
                    Name = scheduleDays.Select(x => x.ScheduleName).FirstOrDefault(),
                    NumberOfDays = scheduleDays
                        .Select(x => x.ScheduleNumberOfDays)
                        .FirstOrDefault(),
                    ScheduleDaysViewModels = scheduleDays
                        .OrderBy(x => x.Name),
                };

                return this.View(viewModel);
            }

            return this.RedirectToAction("Index", "Schedules");
        }

        // GET: Administration/ScheduleDays/Create
        public IActionResult Create(int id)
        {
            var days = this.scheduleDaysServices.GetNamesByScheduleId(id);

            var expectedDaysCount = this.schedulesService.GetNumberOfDaysById(id);
            var scheduleDayNames = Enumerable
                .Range(1, expectedDaysCount);

            var emptyDays = scheduleDayNames.Except(days);

            var viewModel = new ScheduleDayCreateViewModel
            {
                ScheduleDayNames = emptyDays.Select(x => new DayNameDropDownViewModel
                {
                    Name = x,
                }),
                ScheduleId = id,
            };

            return this.View(viewModel);
        }

        // POST: Administration/ScheduleDays/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ScheduleDayCreateViewModel input)
        {
            if (this.ModelState.IsValid)
            {
                var scheduleId = await this.scheduleDaysServices
                    .CreateAsync(input, "Test");

                return this.RedirectToAction("Index", "ScheduleDays", new { id = scheduleId });
            }

            return this.View(input);
        }

        // GET: Administration/ScheduleDays/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var scheduleDay = this.scheduleDaysServices.GetById<ScheduleDayEditViewModel>(id);
            if (scheduleDay == null)
            {
                return this.NotFound();
            }

            return this.View(scheduleDay);
        }

        // POST: Administration/ScheduleDays/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ScheduleDayEditViewModel inputModel)
        {
            if (this.ModelState.IsValid)
            {
                var scheduleId = await this.scheduleDaysServices.UpdateAsync(inputModel, this.Creator());
                return this.RedirectToAction("Index", "ScheduleDays", new { id = scheduleId });
            }

            return this.View(inputModel);
        }

        // GET: Administration/ScheduleDays/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return this.NotFound();
            }

            var scheduleDay = this.scheduleDaysServices.GetById<ScheduleDayDeleteViewModel>(id);

            if (scheduleDay == null)
            {
                return this.NotFound();
            }

            this.TempData["ScheduleId"] = scheduleDay.ScheduleId;

            return this.View(scheduleDay);
        }

        // POST: Administration/ScheduleDays/Delete/5
        [HttpPost]
        [ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await this.scheduleDaysServices.Delete(id, this.Creator());

            var scheduleId = this.TempData["ScheduleId"];

            return this.RedirectToAction("Index", "ScheduleDays", new { id = scheduleId });
        }

        private bool ScheduleExists(int id)
        {
            return this.schedulesService.AnyById(id);
        }

        private string Creator()
        {
            return this.userManager.GetUserAsync(this.User).Result.FullName;
        }
    }
}
