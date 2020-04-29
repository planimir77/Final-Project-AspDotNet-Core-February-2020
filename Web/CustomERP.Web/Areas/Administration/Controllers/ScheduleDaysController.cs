//namespace CustomERP.Web.Areas.Administration.Controllers
//{
//    using System.Linq;
//    using System.Threading.Tasks;

//    using CustomERP.Data;
//    using CustomERP.Data.Common.Repositories;
//    using CustomERP.Data.Models;
//    using CustomERP.Services.Mapping;
//    using CustomERP.Web.ViewModels.Administration.ScheduleDays;
//    using Microsoft.AspNetCore.Mvc;
//    using Microsoft.AspNetCore.Mvc.Rendering;
//    using Microsoft.EntityFrameworkCore;

//    [Area("Administration")]
//    public class ScheduleDaysController : AdministrationController
//    {
//        private readonly IDeletableEntityRepository<ScheduleDay> scheduleDayRepository;
//        private readonly IDeletableEntityRepository<Schedule> scheduleRepository;

//        public ScheduleDaysController(ApplicationDbContext context, IDeletableEntityRepository<ScheduleDay> scheduleDayRepository, IDeletableEntityRepository<Schedule> scheduleRepository)
//        {
//            this.scheduleDayRepository = scheduleDayRepository;
//            this.scheduleRepository = scheduleRepository;
//        }

//        // GET: Production/ScheduleDays/5
//        public IActionResult Index(int id)
//        {
//            var scheduleInfo = this.scheduleRepository
//                .All()
//                .Where(x => x.Id == id)
//                .To<ScheduleInfoModel>().FirstOrDefault();

//            var scheduleDays = this.scheduleDayRepository
//                .All()
//                .Where(x => x.ScheduleId == id)
//                .To<ScheduleDayViewModel>();

//            var viewModel = new ScheduleDayListViewModel
//            {
//                ScheduleId = id,
//                ScheduleInfo = scheduleInfo,
//                ScheduleDaysViewModels = scheduleDays
//                    .OrderBy(x => x.Name),
//            };

//            return this.View(viewModel);
//        }

//        // GET: Production/ScheduleDays/Details/5
//        public async Task<IActionResult> Details(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var shiftDay = await _context.ScheduleDays
//                .Include(s => s.Schedule)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (shiftDay == null)
//            {
//                return NotFound();
//            }

//            return View(shiftDay);
//        }

//        // GET: Production/ScheduleDays/Create
//        public IActionResult Create(int id)
//        {
//            var days = this.scheduleDayRepository.All().Where(x => x.ScheduleId == id).Select(x => x.Name);

//            var scheduleInfo = this.scheduleRepository.All()
//                .Where(x => x.Id == id)
//                .Select(x => new { x.Name, x.NumberOfDays })
//                .FirstOrDefault();

//            var scheduleDayNames = Enumerable.Range(1, scheduleInfo.NumberOfDays);

//            var emptyDays = scheduleDayNames.Except(days);

//            var viewModel = new CreateViewModel
//            {
//                ScheduleDayNames = emptyDays.Select(x => new DayNameDropDownViewModel
//                {
//                    Name = x,
//                }),
//                ScheduleId = id,
//            };

//            return View(viewModel);
//        }

//        // POST: Production/ScheduleDays/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Create(CreateViewModel input)
//        {
//            if (this.ModelState.IsValid)
//            {
//                var shiftDay = new ScheduleDay
//                {
//                    Name = input.Name,
//                    WorkingMode = input.WorkingMode,
//                    Begins = input.Begins.Length > 5 ? null : input.Begins,
//                    CreatedFrom = "Dxcv Gdfgh Ydfgh",
//                    Duration = input.Duration == 0 ? null : input.Duration,
//                    IncludingRest = input.IncludingRest == 0 ? null : input.IncludingRest,
//                    ScheduleId = input.ScheduleId,
//                };

//                await this.scheduleDayRepository.AddAsync(shiftDay);
//                await this.scheduleDayRepository.SaveChangesAsync();
//                return this.RedirectToAction("Index", "ScheduleDays", new { id = shiftDay.ScheduleId });
//            }

//            return View();
//        }

//        // GET: Production/ScheduleDays/Edit/5
//        public async Task<IActionResult> Edit(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var shiftDay = await _context.ScheduleDays.FindAsync(id);
//            if (shiftDay == null)
//            {
//                return NotFound();
//            }
//            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Name", shiftDay.ScheduleId);
//            return View(shiftDay);
//        }

//        // POST: Production/ScheduleDays/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> Edit(int id, [Bind("WorkingMode,Begins,Duration,IncludingRest,ScheduleId,IsDeleted,DeletedOn,DeletedFrom,Id,CreatedOn,ModifiedOn,CreatedFrom,ModifiedFrom")] ScheduleDay shiftDay)
//        {
//            if (id != shiftDay.Id)
//            {
//                return NotFound();
//            }

//            if (ModelState.IsValid)
//            {
//                try
//                {
//                    _context.Update(shiftDay);
//                    await _context.SaveChangesAsync();
//                }
//                catch (DbUpdateConcurrencyException)
//                {
//                    if (!ShiftDayExists(shiftDay.Id))
//                    {
//                        return NotFound();
//                    }
//                    else
//                    {
//                        throw;
//                    }
//                }

//                return this.RedirectToAction("Index", "Schedules");
//            }

//            ViewData["ScheduleId"] = new SelectList(_context.Schedules, "Id", "Name", shiftDay.ScheduleId);
//            return View(shiftDay);
//        }

//        // GET: Production/ScheduleDays/Delete/5
//        public async Task<IActionResult> Delete(int? id)
//        {
//            if (id == null)
//            {
//                return NotFound();
//            }

//            var shiftDay = await _context.ScheduleDays
//                .Include(s => s.Schedule)
//                .FirstOrDefaultAsync(m => m.Id == id);
//            if (shiftDay == null)
//            {
//                return NotFound();
//            }

//            return View(shiftDay);
//        }

//        // POST: Production/ScheduleDays/Delete/5
//        [HttpPost]
//        [ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<IActionResult> DeleteConfirmed(int id)
//        {
//            var shiftDay = await _context.ScheduleDays.FindAsync(id);
//            _context.ScheduleDays.Remove(shiftDay);
//            await _context.SaveChangesAsync();
//            return this.RedirectToAction("Index", "Schedules");
//        }

//        private bool ShiftDayExists(int id)
//        {
//            return _context.ScheduleDays.Any(e => e.Id == id);
//        }
//    }
//}
