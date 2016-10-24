using System.Collections.Generic;

namespace Oxagile.Internal.MVC.Entities.Domain
{
    public class Company : Entity
    {
        public string Name { get; set; }
        public virtual ICollection<User> Users { get; set; }
    }
}
