namespace CustomERP.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class ShiftDay : BaseDeletableModel<int>
    {
        [Required]
        public int Name { get; set; }

        [Required]
        public Mode WorkingMode { get; set; }

        public string Begins { get; set; }

        [Range(0, 12)]
        public int? Duration { get; set; }

        [Range(0, 60)]
        public int? IncludingRest { get; set; }

        [Required]
        public int ScheduleId { get; set; }

        public Schedule Schedule { get; set; }
    }
}
