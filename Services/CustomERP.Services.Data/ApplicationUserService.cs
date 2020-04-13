namespace CustomERP.Services.Data
{
    using System.Threading.Tasks;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using Microsoft.EntityFrameworkCore;

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUserRepository;

        public ApplicationUserService(IDeletableEntityRepository<ApplicationUser> applicationUserRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<string> CreateAsync(
            string fullName, string position, int? shiftId, int? addressId, int? sectionId, string companyId, string managerId)
        {
            var applicationUser = new ApplicationUser
            {
                FullName = fullName,
                Position = position,
                ShiftId = shiftId,
                AddressId = addressId,
                SectionId = sectionId,
                CompanyId = companyId,
                ManagerId = managerId,
            };

            await this.applicationUserRepository.AddAsync(applicationUser);
            await this.applicationUserRepository.SaveChangesAsync();

            return applicationUser.Id;
        }

        public async Task<ApplicationUser> GetByFullName(string fullName)
        {
            var user =
                this.applicationUserRepository.All().FirstOrDefaultAsync(u => u.FullName == fullName);
            return await user;
        }
    }
}
