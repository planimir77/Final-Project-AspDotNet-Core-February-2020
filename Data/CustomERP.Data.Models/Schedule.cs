// ReSharper disable VirtualMemberCallInConstructor

namespace CustomERP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Schedule : BaseDeletableModel<int>
    {
        public Schedule()
        {
            this.CycleOfDays = new ShiftDay[this.NumberOfDays];
            this.Shifts = new HashSet<Shift>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        [Range(1, 30)]
        public int NumberOfDays { get; set; }

        [Required]
        public virtual ShiftDay[] CycleOfDays { get; set; }

        public virtual ICollection<Shift> Shifts { get; set; }
    }
}
