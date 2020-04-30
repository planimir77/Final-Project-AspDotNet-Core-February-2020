namespace CustomERP.Web.ViewModels.Administration.ScheduleDays
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    [Display(Name = "Day")]
    public class ScheduleDayCreateViewModel : IMapFrom<ScheduleDay>
    {
        public int Name { get; set; }

        public IEnumerable<DayNameDropDownViewModel> ScheduleDayNames { get; set; }

        [Required]
        [Display(Name = "Working Mode")]
        public Mode WorkingMode { get; set; }

        [Display(Name = "Begins / in hours")]
        public string Begins { get; set; }

        [Display(Name = "Duration / in hours")]
        public int? Duration { get; set; }

        [Display(Name = "Including Rest / in minutes")]
        public int? IncludingRest { get; set; }

        public int ScheduleId { get; set; }
    }
}
