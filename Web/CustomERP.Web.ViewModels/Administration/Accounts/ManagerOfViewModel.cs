namespace CustomERP.Web.ViewModels.Administration.Accounts
{
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class ManagerOfViewModel : IMapFrom<ApplicationUser>
    {
        public string Id { get; set; }

        public string FullName { get; set; }
    }
}
