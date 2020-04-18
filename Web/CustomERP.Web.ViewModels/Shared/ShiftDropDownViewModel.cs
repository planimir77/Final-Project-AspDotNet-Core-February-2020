using CustomERP.Data.Models;
using CustomERP.Services.Mapping;

namespace CustomERP.Web.ViewModels.Shared
{
    public class ShiftDropDownViewModel : IMapFrom<Shift>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
