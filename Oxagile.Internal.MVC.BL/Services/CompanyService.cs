using System;
using System.Collections.Generic;
using Oxagile.Internal.MVC.BL.Interfaces;
using Oxagile.Internal.MVC.DALCF.Interfaces;
using Oxagile.Internal.MVC.Entities.Domain;

namespace Oxagile.Internal.MVC.BL.Services
{
    public class CompanyService : ICompanyService
    {
        private readonly ICompanyRepository _companyRepository;

        public CompanyService(ICompanyRepository companyRepository)
        {
            if (companyRepository == null)
            {
                throw new ArgumentNullException(nameof(companyRepository));
            }

            _companyRepository = companyRepository;
        }
        public IEnumerable<Company> GetAllCompanies()
        {
            return _companyRepository.GetAll();
        }

        public Company GetCompanyById(int id)
        {
            return _companyRepository.GetSingle(c => c.Id == id, u => u.Users);
        }
    }
}
