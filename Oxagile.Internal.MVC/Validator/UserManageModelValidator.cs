using System;
using FluentValidation;
using Oxagile.Internal.MVC.Models;
using Oxagile.Internal.MVC.Infrastructure.Interfaces;
using Oxagile.Internal.MVC.BL.Interfaces;

namespace Oxagile.Internal.MVC.Validator
{
    public class UserManageModelValidator : AbstractValidator<UserManageModel>
    {
        private readonly ICompanyService _companyService;
        private readonly IConfigService _config;

        public UserManageModelValidator(ICompanyService companyService, IConfigService config)
        {
            if (config == null)
            {
                throw new ArgumentNullException(nameof(config));
            }
            _config = config;
            _companyService = companyService;

            RuleFor(u => u.Name).NotNull();
            RuleFor(u => u.Surname).NotNull();
            RuleFor(u => u.Email).NotNull().EmailAddress();
            RuleFor(u => u.BirthDate).NotNull();
            RuleFor(u => u.CompanyId)
                .Must(CheckCompаniesQuantity)
                .WithMessage("Users limit for this company has been achieved");
        }

        private bool CheckCompаniesQuantity(int id)
        {
            var company = _companyService.GetCompanyById(id);
            var result = company.Users.Count < _config.MaxUsersPerCompany;
            return result;
        }
    }
}