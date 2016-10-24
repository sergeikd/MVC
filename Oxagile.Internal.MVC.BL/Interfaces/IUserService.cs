using System.Collections.Generic;
using Oxagile.Internal.MVC.DALCF;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.BL.Interfaces
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void ManageUser(User user);
        void DeleteUser(User user);
        PagedList<User> GetUserPage(int? page, int pageSize);
        void AddTitleList(IEnumerable<string> titles, User user);
    }
}