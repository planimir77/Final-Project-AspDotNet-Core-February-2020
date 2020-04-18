namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CustomERP.Web.ViewModels.Administration.Accounts;

    public interface IApplicationUserService
    {
        Task<string> RegisterAsync(EmployeeInputViewModel employee);

        IEnumerable<T> GetAll<T>();
    }
}
