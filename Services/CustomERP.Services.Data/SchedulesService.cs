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

        public void Delete(int id)
        {
            var schedule = this.scheduleRepository.All().FirstOrDefault(x => x.Id == id);
            this.scheduleRepository.Delete(schedule);
            this.scheduleRepository.SaveChangesAsync();
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

        public bool AnyByName<T>(string name)
        {
            var schedule = this.scheduleRepository.All().Where(x => x.Name == name).To<T>().FirstOrDefault();
            return schedule == null;
        }

        public T GetById<T>(int? id)
        {
            var schedule = this.scheduleRepository.All().Where(s => s.Id == id).To<T>().FirstOrDefault();
            return schedule;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.scheduleRepository.All().To<T>().ToList();
        }

        public int GetCount()
        {
            return this.scheduleRepository.All().Count();
        }
    }
}
