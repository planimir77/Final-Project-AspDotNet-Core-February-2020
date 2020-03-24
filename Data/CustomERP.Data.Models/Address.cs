// ReSharper disable VirtualMemberCallInConstructor

namespace CustomERP.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Address : BaseDeletableModel<int>
    {
        public Address()
        {
            this.ApplicationUsers = new HashSet<ApplicationUser>();
            this.Companies = new HashSet<Company>();
        }

        [Required]
        public string Country { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string StreetNumber { get; set; }

        public string PostCode { get; set; }

        public int? Floor { get; set; }

        public string Room { get; set; }

        public string Note { get; set; }

        public virtual ICollection<ApplicationUser> ApplicationUsers { get; set; }

        public virtual ICollection<Company> Companies { get; set; }
    }
}
