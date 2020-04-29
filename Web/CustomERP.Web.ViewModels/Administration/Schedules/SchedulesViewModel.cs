namespace CustomERP.Web.ViewModels.Administration.Schedules
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;
    using CustomERP.Web.ViewModels.Administration.ScheduleDays;

    public class SchedulesViewModel : IMapFrom<Schedule>, IMapFrom<ScheduleDay>
    {
        public int Id { get; set; }

        [Display(Name = "Schedule name")]
        public string Name { get; set; }

        [Display(Name = "Days in the cycle")]
        public int NumberOfDays { get; set; }

        public virtual ICollection<ScheduleDayViewModel> CycleOfDays { get; set; }
    }
}