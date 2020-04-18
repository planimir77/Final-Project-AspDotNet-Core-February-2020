namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ShiftsService : IShiftsService
    {
        private readonly IDeletableEntityRepository<Shift> shiftRepository;

        public ShiftsService(IDeletableEntityRepository<Shift> shiftRepository)
        {
            this.shiftRepository = shiftRepository;
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.shiftRepository.All().To<T>().ToList();
        }
    }
}
