namespace CustomERP.Web.ViewModels.Administration.Register
{
    using System.ComponentModel.DataAnnotations;

    public class UserInputViewModel
    {
        [Required]
        [MinLength(8)]
        [MaxLength(50)]
        [Display(Name = "Full Name")]
        [RegularExpression(
            "^([A-Z][a-z]+\\s[A-Z][a-z]+\\s[A-Z][a-z]+|[А-Я][а-я]+\\s[А-Я][а-я]+\\s[А-Я][а-я]+)")]
        public string FullName { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Position { get; set; }
    }
}
