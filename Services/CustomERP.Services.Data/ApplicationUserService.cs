namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Linq;
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

        public async Task<string> RegisterAsync(EmployeeRegisterViewModel employee)
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
            var users =
                this.applicationUserRepository
                .All()
                .Where(x => x.FullName != "First Created Owner")
                .To<T>();

            return users;
        }

        public T GetById<T>(string id)
        {
            var user = this.applicationUserRepository.All().Where(x => x.Id == id).To<T>().FirstOrDefault();

            return user;
        }

        public string GetIdByFullName(string fullName)
        {
            var userId = this.applicationUserRepository.All().FirstOrDefault(x => x.FullName == fullName)?.Id;
            return userId;
        }
    }
}
