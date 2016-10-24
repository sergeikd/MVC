using System;
using System.Collections.Generic;
using System.Linq;
using Oxagile.Internal.MVC.BL.Interfaces;
using Oxagile.Internal.MVC.DALCF;
using Oxagile.Internal.MVC.DALCF.Interfaces;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.BL.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ITitleRepository _titileRepository;

#region Constructor
        public UserService(IUserRepository userRepository, ITitleRepository titileRepository)
        {
            if (userRepository == null)
            {
                throw new ArgumentNullException(nameof(userRepository));
            }

            if (titileRepository == null)
            {
                throw new ArgumentNullException(nameof(titileRepository));
            }

            _userRepository = userRepository;
            _titileRepository = titileRepository;
        }
#endregion

        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll(c => c.Company, t => t.Titles);
        }

        public PagedList<User> GetUserPage(int? page, int usersPerPage)
        {
            var users = _userRepository.GetAll(c => c.Company, t => t.Titles);
            return new PagedList<User>(users, page, usersPerPage);
        }

        public User GetUserById(int id)
        {
            return _userRepository.GetSingle(u => u.Id == id, c => c.Company);
        }

        public void DeleteUser(User user)
        {
            _userRepository.Delete(user);
        }

        public void ManageUser(User user)
        {
            _userRepository.Manage(user);
        }

        public void AddTitleList(IEnumerable<string> titles, User user)
        {
            titles = titles.Where(s => !string.IsNullOrWhiteSpace(s)).Distinct().ToList();
            if (!titles.Any()) return;
            var list = new List<Title>();
            list.AddRange(user.Id == 0
                ? titles.Select(title => new Title { Name = title, User = user })
                : titles.Select(title => new Title { Name = title, UserId = user.Id }));

            _titileRepository.AddRange(list);
        }
    }
}