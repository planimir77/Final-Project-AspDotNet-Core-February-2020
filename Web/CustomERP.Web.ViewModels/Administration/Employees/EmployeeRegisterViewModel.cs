namespace CustomERP.Web.ViewModels.Administration.Employees
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;
    using CustomERP.Web.ViewModels.Shared;

    public class EmployeeRegisterViewModel : IMapFrom<ApplicationUser>
    {
        [Required]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        [RegularExpression(
            "^([A-Z][a-z]+\\s[A-Z][a-z]+\\s[A-Z][a-z]+|[А-Я][а-я]+\\s[А-Я][а-я]+\\s[А-Я][а-я]+)",
            ErrorMessage = "The \"Full Name\" field must be in the format \"Firstname Secondname Lastname\", each beginning with a capital letter, separated by one space.")]
        public string FullName { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The \"Position\" field must be between '3' and '20' characters long", MinimumLength = 3)]
        [MaxLength(20)]
        public string Position { get; set; }

        [Display(Name = "Shift")]
        public int? ShiftId { get; set; }

        public IEnumerable<ShiftDropDownViewModel> Shifts { get; set; }

        public int? AddressId { get; set; }

        [Display(Name = "Section")]
        public int? SectionId { get; set; }

        public IEnumerable<SectionDropDownViewModel> Sections { get; set; }

        [Display(Name = "Company")]
        public string CompanyId { get; set; }

        public IEnumerable<CompanyDropDownViewModel> Companies { get; set; }

        [Display(Name = "Manager")]
        public string ManagerId { get; set; }

        public IEnumerable<ApplicationUserDropDownViewModel> ApplicationUsers { get; set; }

        public string CreatedFrom { get; set; }
    }
}
