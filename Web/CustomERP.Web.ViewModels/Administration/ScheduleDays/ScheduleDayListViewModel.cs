namespace CustomERP.Web.ViewModels.Administration.ScheduleDays
{
    using System.Collections.Generic;

    public class ScheduleDayListViewModel
    {
        public int ScheduleId { get; set; }

        public ScheduleInfoModel ScheduleInfo { get; set; }

        public IEnumerable<ScheduleDayViewModel> ScheduleDaysViewModels { get; set; }
    }
}
