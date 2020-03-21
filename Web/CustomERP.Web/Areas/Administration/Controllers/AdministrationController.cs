namespace CustomERP.Web.Areas.Administration.Controllers
{
    using CustomERP.Common;
    using CustomERP.Web.Controllers;

    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Authorize(Roles = GlobalConstants.RoleName.Administrator)]
    [Area("Administration")]
    public class AdministrationController : BaseController
    {
    }
}
