// ReSharper disable VirtualMemberCallInConstructor
namespace CustomERP.Data.Models
{
    using System.Collections.Generic;

    using CustomERP.Data.Common.Models;

    public class Section : BaseDeletableModel<int>
    {
        public Section()
        {
            this.Employees = new HashSet<Employee>();
        }

        public string Name { get; set; }

        public int? OrderId { get; set; }

        public virtual Order Order { get; set; }

        public int? SectionParentId { get; set; }

        public virtual Section SectionParent { get; set; }

        public virtual ICollection<Employee> Employees { get; set; }

        public virtual ICollection<Section> SectionParents { get; set; }
    }
}
