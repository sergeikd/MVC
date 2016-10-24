using System.Collections.Generic;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.BL.Interfaces
{
    public interface ICompanyService
    {
        IEnumerable<Company> GetAllCompanies();
        Company GetCompanyById(int id);
    }
}
