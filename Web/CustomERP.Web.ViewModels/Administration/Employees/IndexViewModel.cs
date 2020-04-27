namespace CustomERP.Web.ViewModels.Administration.Employees
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexEmployeeViewModel> Users { get; set; }
    }
}
