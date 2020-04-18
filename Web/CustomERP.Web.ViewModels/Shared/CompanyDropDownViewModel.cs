namespace CustomERP.Web.ViewModels.Shared
{
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class CompanyDropDownViewModel : IMapFrom<Company>
    {
        public string Id { get; set; }

        public string Name { get; set; }
    }
}
