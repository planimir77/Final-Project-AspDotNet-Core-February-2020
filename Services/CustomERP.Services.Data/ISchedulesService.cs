namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface ISchedulesService
    {
        Task Delete(int id, string creator);

        Task<int> Update(int id, string name, int numberOfDays, string modifier);

        Task<int> CreateAsync(string name, int numberOfDays, string creator);

        bool AnyByName<T>(string name, int? id);

        T GetById<T>(int? id);

        IEnumerable<T> GetAll<T>();

        int GetCount();

        int GetNumberOfDaysById(int id);

        bool AnyById(int id);
    }
}
