using System.Collections.Generic;

namespace Oxagile.Internal.MVC.Models
{
    public class UserPageViewModel
    {
        public List<UserViewModel> UserViewModel { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}