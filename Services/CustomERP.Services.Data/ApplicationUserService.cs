using Microsoft.EntityFrameworkCore;

namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CustomERP.Data.Common.Repositories;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;
    using CustomERP.Web.ViewModels.Administration.Accounts;

    public class ApplicationUserService : IApplicationUserService
    {
        private readonly IDeletableEntityRepository<ApplicationUser> applicationUserRepository;

        public ApplicationUserService(IDeletableEntityRepository<ApplicationUser> applicationUserRepository)
        {
            this.applicationUserRepository = applicationUserRepository;
        }

        public async Task<string> RegisterAsync(EmployeeInputViewModel employee)
        {
            var applicationUser = new ApplicationUser
            {
                FullName = employee.FullName,
                Position = employee.Position,
                ShiftId = employee.ShiftId,
                AddressId = employee.AddressId,
                SectionId = employee.SectionId,
                CompanyId = employee.CompanyId,
                ManagerId = employee.ManagerId,
                CreatedFrom = employee.CreatedFrom,
            };

            await this.applicationUserRepository.AddAsync(applicationUser);
            await this.applicationUserRepository.SaveChangesAsync();

            return applicationUser.Id;
        }

        public IEnumerable<T> GetAll<T>()
        {
            var users = this.applicationUserRepository.All()
                .To<T>();
            return users;
        }
    }
}
