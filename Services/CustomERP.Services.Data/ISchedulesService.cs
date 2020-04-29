namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISchedulesService
    {
        void Delete(int id);

        Task<int> Update(int id, string name, int numberOfDays, string modifier);

        Task<int> CreateAsync(string name, int numberOfDays, string creator);

        bool AnyByName<T>(string name);

        T GetById<T>(int? id);

        IEnumerable<T> GetAll<T>();

        int GetCount();
    }
}
