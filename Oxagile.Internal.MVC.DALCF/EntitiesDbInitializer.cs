using System;
using System.Collections.Generic;
using System.Data.Entity;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.DALCF
{
    public class EntitiesDbInitializer : DropCreateDatabaseAlways<AppContext>
    {
        protected override void Seed(AppContext db)
        {
            var company1 = new Company {Name = "Company1"};
            var company2 = new Company {Name = "Company2"};
            var company3 = new Company {Name = "Company3"};
            db.Companies.AddRange(new List<Company> {company1, company2, company3});
            db.SaveChanges();

            var userList = new List<User>();
            for (var i = 1; i < 46; i++)
            {
                userList.Add(new User
                {
                    Name = "Name" + i,
                    Surname = "Surname" + i,
                    Email = "email" + i + "@email.com",
                    BirthDate = new DateTime(1980 + i%15, i%12 + 1, i%30 + 1),
                    CompanyId = i%3 + 1
                });
            }

            userList[0].PhotoFileName = "genovav.png";
            userList[1].PhotoFileName = "shukailoal.png";
            userList[2].PhotoFileName = "bakhtiniv.png";
            db.Users.AddRange(userList);
            db.SaveChanges();

            var titleList = new List<Title>
            {
                new Title {Name = "Title1", UserId = 1},
                new Title {Name = "Title2", UserId = 1},
                new Title {Name = "Title3", UserId = 2}
            };
            db.Titles.AddRange(titleList);
            db.SaveChanges();
        }
    }
}