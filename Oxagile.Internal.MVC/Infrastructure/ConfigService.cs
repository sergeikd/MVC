using System;
using System.Configuration;
using Oxagile.Internal.MVC.Infrastructure.Interfaces;

namespace Oxagile.Internal.MVC.Infrastructure
{
    public class ConfigService : IConfigService
    {
        public short UsersPerPage => Convert.ToInt16(ConfigurationManager.AppSettings["UsersPerPage"]);
        public short MaxUsersPerCompany => Convert.ToInt16(ConfigurationManager.AppSettings["UsersPerCompany"]);
        public string PathToImages => ConfigurationManager.AppSettings["PathToImages"];
        public short IcoWidth => Convert.ToInt16(ConfigurationManager.AppSettings["IcoWidth"]);
        public short IcoHeight => Convert.ToInt16(ConfigurationManager.AppSettings["IcoHeight"]);
    }
}