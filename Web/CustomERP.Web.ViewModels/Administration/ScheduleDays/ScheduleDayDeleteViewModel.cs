namespace CustomERP.Web.ViewModels.Administration.ScheduleDays
{
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ScheduleDayDeleteViewModel : IMapFrom<ScheduleDay>
    {
        public int Id { get; set; }

        public int Name { get; set; }

        [Display(Name = "Working Mode")]
        public Mode WorkingMode { get; set; }

        [Display(Name = "Begins")]
        public string Begins { get; set; }

        [Display(Name = "Duration")]
        public int? Duration { get; set; }

        [Display(Name = "Including Rest")]
        public int? IncludingRest { get; set; }

        public int ScheduleId { get; set; }

        [Display(Name = "from Schedule")]
        public string ScheduleName { get; set; }
    }
}
