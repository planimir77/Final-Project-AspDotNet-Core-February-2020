namespace CustomERP.Web.ViewModels.Administration.ScheduleDays
{
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ScheduleDayViewModel : IMapFrom<ScheduleDay>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int Name { get; set; }

        [Display(Name = "Day")]
        public string DayName { get; set; }

        [Display(Name = "Mode")]
        public Mode WorkingMode { get; set; }

        [Display(Name = "Begins")]
        [RegularExpression("^(0[0-9]|1[0-9]|2[0-3]):[0-5][0-9]$")]
        public string Begins { get; set; }

        [Display(Name = "Duration")]
        public int? Duration { get; set; }

        [Display(Name = "Including rest")]
        public int? IncludingRest { get; set; }

        public string ScheduleName { get; set; }

        public int ScheduleNumberOfDays { get; set; }

        public void CreateMappings(IProfileExpression configuration)
        {
            configuration.CreateMap<ScheduleDay, ScheduleDayViewModel>().ForMember(
                m => m.DayName,
                opt => opt.MapFrom(x => "Day " + x.Name));
        }
    }
}
