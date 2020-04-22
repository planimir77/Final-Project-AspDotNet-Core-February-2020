namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class CompaniesService : ICompaniesService
    {
        private readonly IDeletableEntityRepository<Company> companyRepository;

        public CompaniesService(IDeletableEntityRepository<Company> companyRepository)
        {
            this.companyRepository = companyRepository;
        }

        public int GetCount()
        {
            return this.companyRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.companyRepository.All().To<T>().ToList();
        }
    }
}
