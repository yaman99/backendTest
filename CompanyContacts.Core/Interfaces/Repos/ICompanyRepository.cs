using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyContacts.Core.Interfaces.Repos
{
    public interface ICompanyRepository
    {
        Task<IEnumerable<Company>> GetAllCompanies();
        Task<CompanyContactVM> GetCompanyContract(string companyId);
        Task<bool> AddCompany(Company company);
        Task<bool> removeCompany(string id);
        Task<bool> UpdateCompanyContact(string companyId , ContactVM contact);
        Task<bool> DeleteCompanyContact(string contactId, string companyId);

    }
}
