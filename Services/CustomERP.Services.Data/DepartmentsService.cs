namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class DepartmentsService : IDepartmentsService
    {
        private readonly IDeletableEntityRepository<Department> departmentsRepository;

        public DepartmentsService(IDeletableEntityRepository<Department> departmentsRepository)
        {
            this.departmentsRepository = departmentsRepository;
        }

        public int GetCount()
        {
            return this.departmentsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.departmentsRepository.All().To<T>().ToList();
        }
    }
}
