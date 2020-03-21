// ReSharper disable VirtualMemberCallInConstructor
namespace CustomERP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Order : BaseDeletableModel<int>
    {
        public Order()
        {
            this.Sections = new HashSet<Section>();
        }

        public string Customer { get; set; }

        [Required]
        public string Recipe { get; set; }

        public int Quantity { get; set; }

        [Required]
        public int ContentWeight { get; set; }

        public int Progress { get; set; }

        public bool IsActive { get; set; }

        public DateTime? CompletedOn { get; set; }

        public string Note { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
