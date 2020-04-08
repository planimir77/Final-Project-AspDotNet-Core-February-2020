namespace CustomERP.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class ShiftDay : BaseDeletableModel<int>
    {
        [Required] public Mode WorkingMode { get; set; }

        [Required] public DateTime Begins { get; set; }

        [Required] public TimeSpan Duration { get; set; }

        [Required] public TimeSpan IncludingRest { get; set; }

        [Required] public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }

    }
}
