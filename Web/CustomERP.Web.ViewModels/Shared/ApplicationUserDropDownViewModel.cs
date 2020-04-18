namespace CustomERP.Web.ViewModels.Shared
{
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ApplicationUserDropDownViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FullName { get; set; }
    }
}
