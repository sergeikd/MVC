using System.Data.Entity;
using Oxagile.Internal.MVC.DALCF.Interfaces;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF.Repositories
{
    public class TitleRepository : BaseRepository<Title>, ITitleRepository
    {

        public TitleRepository(DbContext dbContext)
            : base(dbContext)
        {}

    }
}
