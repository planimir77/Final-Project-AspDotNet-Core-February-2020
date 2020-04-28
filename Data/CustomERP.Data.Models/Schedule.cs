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
            this.Teams = new HashSet<Team>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 60)]
        public int NumberOfDays { get; set; }

        [Required]
        public virtual ICollection<ScheduleDay> CycleOfDays { get; set; }

        public virtual ICollection<Team> Teams { get; set; }
    }
}
