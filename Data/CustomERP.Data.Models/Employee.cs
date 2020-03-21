// ReSharper disable VirtualMemberCallInConstructor

using System.Collections.Generic;

namespace CustomERP.Data.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Common.Models;

    public class Employee : BaseDeletableModel<string>
    {
        private Employee()
        {
            this.Id = Guid.NewGuid().ToString();
        }

        [MinLength(8)]
        [RegularExpression(
            "^([A-Z][a-z]+\\s[A-Z][a-z]+\\s[A-Z][a-z]+|[А-Я][а-я]+\\s[А-Я][а-я]+\\s[А-Я][а-я]+)")]
        public string FullName { get; set; }

        public string Position { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime HireDate { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public int? AddressId { get; set; }

        public virtual Address EmployeeAddress { get; set; }

        public int? SectionId { get; set; }

        public virtual Section Section { get; set; }

#nullable enable

        public string? EmployeeManagerId { get; set; }

        public virtual Employee EmployeeManager { get; set; }

        public string? CompanyId { get; set; }

        public virtual Company Company { get; set; }

        public virtual ApplicationUser UserAccount { get; set; }

        public virtual ICollection<Employee> Managers { get; set; }
    }
}
