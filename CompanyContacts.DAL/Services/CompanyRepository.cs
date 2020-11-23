using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using CompanyContacts.Core.Interfaces.Repos;
using System.Threading.Tasks;
using CompanyContacts.Core.Models.CompanyDTO;
using CompanyContacts.DAL.Common;
using Microsoft.Extensions.Options;
using CompanyContacts.Core.Entities;

namespace CompanyContacts.DAL.Services
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly DbContext _context = null;
        public CompanyRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new DbContext(settings);
        }
        public async Task<bool> AddCompany(Company company)
        {
            try
            {
                await _context.Company.InsertOneAsync(company);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            try
            {
                return  await _context.Company.Find(_ => true).ToListAsync();      
            }
            catch (Exception ex)
            {
                // log or manage the exception
                throw ex;
            }
        }

        public async Task<bool> removeCompany(string id)
        {
            var res =  await _context.Company.DeleteOneAsync(x => x.Id == id);
            if (res.IsAcknowledged)
                return true;
            return false;
        }
    }
}
