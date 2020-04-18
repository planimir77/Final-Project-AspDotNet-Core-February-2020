namespace CustomERP.Web.ViewModels.Administration.Accounts
{
    using System.Collections.Generic;

    public class IndexViewModel
    {
        public IEnumerable<IndexEmployeeViewModel> Users { get; set; }
    }
}
