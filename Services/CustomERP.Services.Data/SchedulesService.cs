namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class SchedulesService : ISchedulesService
    {
        private readonly IDeletableEntityRepository<Schedule> scheduleRepository;

        public SchedulesService(IDeletableEntityRepository<Schedule> scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public async Task Delete(int id, string creator)
        {
            var schedule = this.scheduleRepository.All().FirstOrDefault(x => x.Id == id);
            if (schedule != null)
            {
                schedule.DeletedFrom = creator;
                this.scheduleRepository.Delete(schedule);
                await this.scheduleRepository.SaveChangesAsync();
            }
        }

        public async Task<int> Update(int id, string name, int numberOfDays, string modifier)
        {
            var schedule = this.scheduleRepository.All().FirstOrDefault(x => x.Id == id);

            if (schedule != null)
            {
                schedule.Name = name;
                schedule.NumberOfDays = numberOfDays;
            }

            await this.scheduleRepository.SaveChangesAsync();

            return id;
        }

        public async Task<int> CreateAsync(string name, int numberOfDays, string creator)
        {
            var schedule = new Schedule
            {
                Name = name,
                NumberOfDays = numberOfDays,
                CreatedFrom = creator,
            };

            await this.scheduleRepository.AddAsync(schedule);
            await this.scheduleRepository.SaveChangesAsync();

            return schedule.Id;
        }

        public bool AnyByName<T>(string name, int? id)
        {
            var schedule = this.scheduleRepository
                .All().Where(x => x.Name == name && x.Id != id)
                .To<T>().FirstOrDefault();
            return schedule != null;
        }

        public T GetById<T>(int? id)
        {
            var schedule = this.scheduleRepository
                .All()
                .Where(s => s.Id == id)
                .To<T>().FirstOrDefault();
            return schedule;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.scheduleRepository
                .All().To<T>().ToList();
        }

        public int GetCount()
        {
            return this.scheduleRepository.All().Count();
        }

        public int GetNumberOfDaysById(int id)
        {
            return this.scheduleRepository
                .All()
                .Where(x => x.Id == id)
                .Select(x => x.NumberOfDays)
                .FirstOrDefault();
        }

        public bool AnyById(int id)
        {
            var result = this.scheduleRepository.All().FirstOrDefault(x => x.Id == id);

            return result != null;
        }
    }
}
