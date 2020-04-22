using System.Linq;
using CustomERP.Data.Common.Repositories;
using CustomERP.Data.Models;

namespace CustomERP.Services.Data
{
    public class SchedulesService : ISchedulesService
    {
        private readonly IDeletableEntityRepository<Schedule> scheduleRepository;

        public SchedulesService(IDeletableEntityRepository<Schedule> scheduleRepository)
        {
            this.scheduleRepository = scheduleRepository;
        }

        public int GetCount()
        {
            return this.scheduleRepository.All().Count();
        }
    }
}
