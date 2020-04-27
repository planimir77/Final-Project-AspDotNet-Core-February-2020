namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CustomERP.Web.ViewModels.Administration.Employees;

    public interface IApplicationUserService
    {
        Task<string> RegisterAsync(EmployeeRegisterViewModel employee);

        int GetCount();

        IEnumerable<T> GetAll<T>();

        T GetById<T>(string id);

        string GetIdByFullName(string fullName);

        Task<string> Update(EmployeeEditInputModel inputModel);

        Task<string> DeleteById(string id, string admin);
    }
}
