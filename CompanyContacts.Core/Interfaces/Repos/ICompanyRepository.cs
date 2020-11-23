using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Models;
using CompanyContacts.Core.Models.CompanyDTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyContacts.Core.Interfaces.Repos
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<bool> AddCompany(Company company);
        Task<bool> removeCompany(string id);


    }
}
