namespace Oxagile.Internal.MVC.Infrastructure.Interfaces
{
    public interface IConfigService
    {
        short UsersPerPage { get; }
        short MaxUsersPerCompany { get; }
        string PathToImages { get; }
        short IcoWidth { get; }
        short IcoHeight { get; }
    }
}
