using CustomERP.Data.Models;
using CustomERP.Services.Mapping;

namespace CustomERP.Web.ViewModels.Shared
{
    public class ApplicationUserDropDownViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FullName { get; set; }
    }
}
