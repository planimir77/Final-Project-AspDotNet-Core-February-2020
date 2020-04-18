using System.Security;
using System.Threading.Tasks;

namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class SectionsService : ISectionsService
    {
        private readonly IDeletableEntityRepository<Section> sectionsRepository;

        public SectionsService(IDeletableEntityRepository<Section> sectionsRepository)
        {
            this.sectionsRepository = sectionsRepository;
        }

        public async Task<int> CreateAsync(string name, int departmentId, int? sectionParentId, string userId)
        {
            var section = new Section
            {
                Name = name,
                DepartmentId = departmentId,
                SectionParentId = sectionParentId,
                CreatedFrom = userId,
            };

            await this.sectionsRepository.AddAsync(section);
            await this.sectionsRepository.SaveChangesAsync();

            return section.Id;
        }

        public async Task<int> Update(int id, string name, int departmentId, int? sectionParentId, string userId)
        {
            var section = await this.sectionsRepository.GetByIdWithDeletedAsync(id);

            this.sectionsRepository.Update(section);

            return id;
        }

        public int GetCount()
        {
            return this.sectionsRepository.All().Count();
        }

        public IEnumerable<T> GetAll<T>()
        {
            return this.sectionsRepository.All().To<T>().ToList();
        }

        public T GetById<T>(int id)
        {
          var section = this.sectionsRepository.All().Where(s => s.Id == id).To<T>().FirstOrDefault();
          return section;
        }
    }
}
