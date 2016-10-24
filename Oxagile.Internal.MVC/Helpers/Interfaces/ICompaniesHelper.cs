using Oxagile.Internal.MVC.Entities.Domain;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Oxagile.Internal.MVC.Helpers.Interfaces
{
    public interface ICompaniesHelper
    {
        List<SelectListItem> GetDropDownList(List<Company> list);
    }
}