// ReSharper disable VirtualMemberCallInConstructor

namespace CustomERP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Schedule : BaseDeletableModel<int>
    {
        public Schedule()
        {
            this.CycleOfDays = new HashSet<ScheduleDay>();
            this.Shifts = new HashSet<Shift>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 60)]
        public int NumberOfDays { get; set; }

        [Required]
        public virtual ICollection<ScheduleDay> CycleOfDays { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
