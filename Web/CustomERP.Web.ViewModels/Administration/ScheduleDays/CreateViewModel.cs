namespace CustomERP.Web.ViewModels.Administration.ScheduleDays
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    [Display(Name = "Day")]
    public class CreateViewModel : IMapFrom<ScheduleDay>
    {
        public int Name { get; set; }

        public IEnumerable<DayNameDropDownViewModel> ScheduleDayNames { get; set; }

        [Required]
        public Mode WorkingMode { get; set; }

        public string Begins { get; set; }

        public int? Duration { get; set; }

        public int? IncludingRest { get; set; }

        public int ScheduleId { get; set; }
    }
}
