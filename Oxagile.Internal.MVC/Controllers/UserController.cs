using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Oxagile.Internal.MVC.BL.Interfaces;
using Oxagile.Internal.MVC.Models;
using Oxagile.Internal.MVC.CustomActionAttribute;
using Oxagile.Internal.MVC.Entities.Domain;
using Oxagile.Internal.MVC.Infrastructure.Interfaces;
using System.Web;
using Oxagile.Internal.MVC.Helpers.Interfaces;

namespace Oxagile.Internal.MVC.Controllers
{
    public class UserController : BaseController
    {
        private readonly IUserService _userService;
        private readonly IConfigService _configService;
        private readonly ICompanyService _companyService;
        private readonly ICompaniesHelper _companiesHelper;
        private readonly IImageService _imageService;

        #region Constructor
        public UserController(IUserService userService, IConfigService configService, ICompanyService companyService, ICompaniesHelper companiesHelper, IImageService imageService)
        {
            if (userService == null)
            {
                throw new ArgumentNullException(nameof(userService));
            }

            if (configService == null)
            {
                throw new ArgumentNullException(nameof(configService));
            }

            if (companyService == null)
            {
                throw new ArgumentNullException(nameof(configService));
            }

            if (companiesHelper == null)
            {
                throw new ArgumentNullException(nameof(companiesHelper));
            }

            if (imageService == null)
            {
                throw new ArgumentNullException(nameof(imageService));
            }
            _userService = userService;
            _configService = configService;
            _companyService = companyService;
            _companiesHelper = companiesHelper;
            _imageService = imageService;
        }
        #endregion
        [HttpGet]
        public ActionResult Users(int? page)
        {
            var pageUsers = _userService.GetUserPage(page, _configService.UsersPerPage);

            var listUserView = pageUsers.Select(item => new UserViewModel
            {
                Id = item.Id,
                Name = item.Name,
                Surname = item.Surname,
                PhotoFileName = item.PhotoFileName,
                BirthDate = item.BirthDate,
                Email = item.Email,
                Company = item.Company.Name,
                Titles = item.Titles.Select(x => x.Name).ToList()}).ToList();
            var pageInfo = new PageInfo { PageNumber = pageUsers.Page, PageSize = pageUsers.PageSize, TotalItems = pageUsers.TotalCount };
            ViewBag.PathToImages = _configService.PathToImages;

            return View(new UserPageViewModel { UserViewModel = listUserView, PageInfo = pageInfo });
        }

        [HttpGet]
        public ActionResult Manage(int? id)
        {
            var user = id != null
                ? _userService.GetUserById((int) id)
                : new User { BirthDate = new DateTime(1980,1,1) , CompanyId = 1, Name = string.Empty, Surname = string.Empty, Titles = new List<Title>()};

            if(user == null) return HttpNotFound("User not found");

            var managedUser = new UserManageModel
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                PhotoFileName = user.PhotoFileName,
                BirthDate = user.BirthDate,
                Titles = user.Titles.Select(t => t.Name).ToList(),
                Email = user.Email,
                CompanyId = user.CompanyId,
                Companies = _companiesHelper.GetDropDownList(_companyService.GetAllCompanies().ToList())
            };

            return View("Manage", managedUser);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [MultipleButton(Name = "action", Argument = "Save")]
        public ActionResult Manage(UserManageModel user, HttpPostedFileBase file)
        {
            if (!ModelState.IsValid)
            {
                user.Companies = _companiesHelper.GetDropDownList(_companyService.GetAllCompanies().ToList());
                return View("Manage", user);
            }
            var oldPhotoFileName = user.PhotoFileName;

            var managedUser = new User
            {
                Id = user.Id,
                Name = user.Name,
                Surname = user.Surname,
                Email = user.Email,
                BirthDate = user.BirthDate,
                CompanyId = user.CompanyId,
                PhotoFileName = file==null ? 
                        (user.PhotoFileName != null? null : user.PhotoFileName) : _imageService.GetImageFileName(user.Name, user.Surname, file.FileName)
            };
            _userService.ManageUser(managedUser);
            if (file != null)
                _imageService.ManagePhoto(file.InputStream, oldPhotoFileName, managedUser.PhotoFileName);

            if (user.NewTitles != null)
                _userService.AddTitleList(user.NewTitles, managedUser);
            

            return RedirectToAction("Users");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int? id)
        {
            if (id == null) return HttpNotFound("User not found");
            var user = _userService.GetUserById((int) id);

            if (user == null) return HttpNotFound("User not found");
            _userService.DeleteUser(user);
            return RedirectToAction("Users");
        }

        [HttpPost]
        [MultipleButton(Name = "action", Argument = "AddField")]
        public ActionResult AddField(UserManageModel user)
        {
            if (user.NewTitles == null)
                user.NewTitles = new List<string>();

            user.NewTitles.Add(string.Empty);
            user.Companies = _companiesHelper.GetDropDownList(_companyService.GetAllCompanies().ToList());
            return View("Manage", user);
        }
    }
}