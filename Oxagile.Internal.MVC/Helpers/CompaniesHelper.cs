using Oxagile.Internal.MVC.Entities.Domain;
using Oxagile.Internal.MVC.Helpers.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace Oxagile.Internal.MVC.Helpers
{
    public class CompaniesHelper : ICompaniesHelper
    {
        public List<SelectListItem> GetDropDownList(List<Company> list)
        {
            return list.Select(company => new SelectListItem {Text = company.Name, Value = company.Id.ToString()}).ToList();
        }
    }
}