namespace CustomERP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Department : BaseDeletableModel<int>
    {
        public Department()
        {
            // ReSharper disable once VirtualMemberCallInConstructor
            this.Sections = new HashSet<Section>();
        }

        [Required]
        public string Name { get; set; }

        public virtual ICollection<Section> Sections { get; set; }
    }
}
