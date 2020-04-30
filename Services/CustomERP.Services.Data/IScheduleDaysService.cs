namespace CustomERP.Services.Data
{
    using System.Collections.Generic;
    using System.Threading.Tasks;

    using CustomERP.Web.ViewModels.Administration.ScheduleDays;

    public interface IScheduleDaysService
    {
        T GetById<T>(int? id);

        Task Delete(int id, string creator);

        Task<int> CreateAsync(ScheduleDayCreateViewModel model, string creator);

        IEnumerable<T> GetAllByScheduleId<T>(int? id);

        IEnumerable<int> GetNamesByScheduleId(int? id);

        Task<int> UpdateAsync(ScheduleDayEditViewModel model, string modifier);

        int GetDaysCountByScheduleId(int scheduleId);
    }
}
