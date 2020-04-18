namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISectionsService
    {
        Task<int> CreateAsync(string name, int departmentId, int? sectionParentId, string userId);

        Task<int> Update(int id, string name, int departmentId, int? sectionParentId, string userId);

        int GetCount();

        IEnumerable<T> GetAll<T>();

        T GetById<T>(int id);
    }
}
