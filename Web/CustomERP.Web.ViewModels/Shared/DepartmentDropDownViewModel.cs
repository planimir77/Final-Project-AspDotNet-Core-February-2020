namespace CustomERP.Web.ViewModels.Shared
{
    using CustomERP.Data.Models;
    using CustomERP.Services.Mapping;

    public class DepartmentDropDownViewModel : IMapFrom<Department>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
