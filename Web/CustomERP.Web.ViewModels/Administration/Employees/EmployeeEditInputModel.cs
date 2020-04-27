namespace CustomERP.Web.ViewModels.Administration.Employees
{
    using System;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class EmployeeEditInputModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        [Required]
        [MaxLength(50)]
        [RegularExpression(
            "^([A-Z][a-z]+\\s[A-Z][a-z]+\\s[A-Z][a-z]+|[А-Я][а-я]+\\s[А-Я][а-я]+\\s[А-Я][а-я]+)",
            ErrorMessage = "The \"Full Name\" field must be in the format \"Firstname Secondname Lastname\", each beginning with a capital letter, separated by one space.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The \"Position\" field must be between '3' and '20' characters long", MinimumLength = 3)]
        [MaxLength(20)]
        public string Position { get; set; }

        public int? ShiftId { get; set; }

        public int? AddressId { get; set; }

        public int? SectionId { get; set; }

        public string CompanyId { get; set; }

        public string ManagerId { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public string ModifiedFrom { get; set; }
    }
}
