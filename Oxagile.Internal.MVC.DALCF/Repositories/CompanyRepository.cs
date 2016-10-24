using System.Data.Entity;
using Oxagile.Internal.MVC.DALCF.Interfaces;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF.Repositories
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(DbContext dbContext)
            : base(dbContext)
        { }
    }
}
