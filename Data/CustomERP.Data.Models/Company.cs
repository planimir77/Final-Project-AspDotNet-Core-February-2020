// ReSharper disable VirtualMemberCallInConstructor
namespace CustomERP.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Company : BaseDeletableModel<string>
    {
        public Company()
        {
            this.Id = Guid.NewGuid().ToString();
            this.ApplicationUsers = new HashSet<ApplicationUser>();
        }

        [Required]
        public string Name { get; set; }

        public int? AddressId { get; set; }

        public virtual Address CompanyAddress { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }
    }
}
