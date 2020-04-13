using CustomERP.Data.Models;

namespace CustomERP.Services.Data
{
    using System.Threading.Tasks;

    public interface IApplicationUserService
    {
        Task<string> CreateAsync(string fullName, string position, int? shiftId, int? addressId,
            int? sectionId,string companyId,  string managerId);

        Task<ApplicationUser> GetByFullName(string fullName);
    }
}
