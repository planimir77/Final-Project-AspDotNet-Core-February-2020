using CustomERP.Data.Models;
using CustomERP.Services.Mapping;

namespace CustomERP.Web.ViewModels.Shared
{
    public class DepartmentDropDownViewModel : IMapFrom<Department>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
