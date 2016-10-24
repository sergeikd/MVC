
namespace Oxagile.Internal.MVC.Entities.Domain
{
    public class Title : Entity
    {
        public string Name { get; set; }
        public int UserId { get; set; }
        public virtual User User { get; set; }
    }
}
