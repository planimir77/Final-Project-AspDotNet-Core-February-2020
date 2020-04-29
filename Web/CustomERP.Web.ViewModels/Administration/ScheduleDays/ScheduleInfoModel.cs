namespace CustomERP.Web.ViewModels.Administration.ScheduleDays
{
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ScheduleInfoModel : IMapFrom<Schedule>
    {
        public string Name { get; set; }

        public int NumberOfDays { get; set; }
    }
}
