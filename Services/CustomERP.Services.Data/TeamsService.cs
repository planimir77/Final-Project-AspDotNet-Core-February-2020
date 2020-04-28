namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class TeamsService : ITeamsService
    {
        private readonly IDeletableEntityRepository<Team> teamRepository;

        public TeamsService(IDeletableEntityRepository<Team> teamRepository)
        {
            this.teamRepository = teamRepository;
        }

        public int GetCount()
        {
            return this.teamRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.teamRepository.All().To<T>().ToList();
        }
    }
}
