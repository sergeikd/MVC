using System.Data.Entity;
using Oxagile.Internal.MVC.DALCF.Interfaces;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF.Repositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(DbContext dbContext)
            : base(dbContext)
        {}
    }
}
