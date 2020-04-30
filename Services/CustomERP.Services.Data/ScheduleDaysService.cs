namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;
    using CustomERP.Web.ViewModels.Administration.ScheduleDays;

    public class ScheduleDaysService : IScheduleDaysService
    {
        private readonly IDeletableEntityRepository<ScheduleDay> scheduleDayRepository;

        public ScheduleDaysService(IDeletableEntityRepository<ScheduleDay> scheduleDayRepository)
        {
            this.scheduleDayRepository = scheduleDayRepository;
        }

        public T GetById<T>(int? id)
        {
            var scheduleDay = this.scheduleDayRepository
                .All()
                .Where(s => s.Id == id)
                .To<T>().FirstOrDefault();

            return scheduleDay;
        }

        public async Task<int> CreateAsync(ScheduleDayCreateViewModel model, string creator)
        {
            var scheduleDay = new ScheduleDay
            {
                Name = model.Name,
                WorkingMode = model.WorkingMode,
                Begins = model.Begins.Length > 5 ? null : model.Begins,
                CreatedFrom = creator,
                Duration = model.Duration == 0 ? null : model.Duration,
                IncludingRest = model.IncludingRest == 0 ? null : model.IncludingRest,
                ScheduleId = model.ScheduleId,
            };

            await this.scheduleDayRepository.AddAsync(scheduleDay);
            await this.scheduleDayRepository.SaveChangesAsync();

            return scheduleDay.ScheduleId;
        }

        public IEnumerable<T> GetAllByScheduleId<T>(int? id)
        {
            var scheduleDay = this.scheduleDayRepository
                .All()
                .Where(x => x.ScheduleId == id)
                .To<T>()
                .ToList();

            return scheduleDay;
        }

        public IEnumerable<int> GetNamesByScheduleId(int? id)
        {
            var days = this.scheduleDayRepository
                .All()
                .Where(x => x.ScheduleId == id)
                .Select(x => x.Name);

            return days;
        }

        public async Task<int> UpdateAsync(ScheduleDayEditViewModel model, string modifier)
        {
            var scheduleDay = this.scheduleDayRepository
                .All()
                .FirstOrDefault(x => x.Id == model.Id);

            if (scheduleDay != null)
            {
                scheduleDay.Name = model.Name;
                scheduleDay.WorkingMode = model.WorkingMode;
                scheduleDay.Begins = model.Begins.Length > 5 ? null : model.Begins;
                scheduleDay.Duration = model.Duration == 0 ? null : model.Duration;
                scheduleDay.IncludingRest = model.IncludingRest == 0 ? null : model.IncludingRest;
                scheduleDay.ModifiedFrom = modifier;
            }

            await this.scheduleDayRepository.SaveChangesAsync();

            return model.ScheduleId;
        }

        public int GetDaysCountByScheduleId(int scheduleId)
        {
            return this.scheduleDayRepository
                .All()
                .Count(x => x.ScheduleId == scheduleId);
        }

        public async Task Delete(int id, string creator)
        {
            var scheduleDay = this.scheduleDayRepository.All()
                .FirstOrDefault(x => x.Id == id);

            if (scheduleDay != null)
            {
                scheduleDay.DeletedFrom = creator;
                this.scheduleDayRepository.Delete(scheduleDay);
                await this.scheduleDayRepository.SaveChangesAsync();
            }
        }
    }
}
