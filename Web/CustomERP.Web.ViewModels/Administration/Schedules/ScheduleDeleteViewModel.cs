namespace CustomERP.Web.ViewModels.Administration.Schedules
{
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ScheduleDeleteViewModel : IMapFrom<Schedule>
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [Range(2, 30)]
        public int NumberOfDays { get; set; }
    }
}
