using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using CompanyContacts.Core.Interfaces.Repos;
using System.Threading.Tasks;
using CompanyContacts.DAL.Common;
using Microsoft.Extensions.Options;
using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Models;
using MongoDB.Bson;

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


        public async Task<CompanyContactVM> GetCompanyContract(string companyId)
        {
            // Trying To Make It Join With MongoDb insted of this implementation 

            var company = await _context.Company.Find(x => x.Id == companyId).FirstAsync();
            var contacts = await _context.Contact.Find(_ => true).ToListAsync();

            List<ContactVM> companyContacts = new List<ContactVM>();

            foreach (var contact in contacts)
            {
                foreach (var companyContact in contact.Companies)
                {
                    if (companyContact.Id == company.Id)
                    {
                        companyContacts.Add(new ContactVM { Id = contact.Id, Name = contact.Name  , OtherData = contact.OtherData});
                    }
                }
            }

            return new CompanyContactVM
            {
                Id = company.Id,
                Name = company.Name,
                NumOfEmployees = company.NumOfEmployees,
                Contact = companyContacts
            };
        }

        public async Task<bool> UpdateCompanyContact(string companyId , ContactVM contactBody)
        {
            var contact = await _context.Contact.Find(x => x.Id == contactBody.Id).FirstAsync();
            List<Company> newCompany = new List<Company>();

            if (contact.Id == contactBody.Id)
            {
                foreach (var companyContact in contact.Companies)
                {
                    if (companyContact.Id == companyId)
                    {
                        contact.Companies.Remove(companyContact);
                        newCompany.Add(companyContact);

                        var data = new Contact
                        {
                            Id = ObjectId.GenerateNewId().ToString(),
                            Name = contactBody.Name,
                            OtherData = contactBody.OtherData,
                            Companies = newCompany
                        };

                        await _context.Contact.InsertOneAsync(data);

                        var result = UpdateContact(contact);

                        return true;
                    }
                }
            }
            return false;
        }

        private async Task<bool> UpdateContact(Contact contact)
        {
            var filter = Builders<Contact>.Filter
                            .Eq(x => x.Id, contact.Id);

            var update = Builders<Contact>.Update
                            .Set(s => s.Companies, contact.Companies);

            await _context.Contact.UpdateOneAsync(filter, update);

            return true;

        }

        public async Task<bool> DeleteCompanyContact(string contactId , string companyId)
        {
            var contact = await _context.Contact.Find(x => x.Id == contactId)
                                                .Project(x=>x.Companies)
                                                .FirstAsync();

            if (contact != null)
            {
                foreach (var companyContact in contact)
                {
                    if (companyContact.Id == companyId)
                    {
                        contact.Remove(companyContact);
                        break;
                    }
                }

                var filter = Builders<Contact>.Filter
                            .Eq(x => x.Id , contactId);

                var update = Builders<Contact>.Update
                                .Set(s => s.Companies, contact);

                var result = await _context.Contact.UpdateOneAsync(filter, update);
                return true;
            }
            return false;
        }

        public bool IsUserExist(string Name)
        {
            var result =  _context.Company.Find(x => x.Name == Name).CountDocuments();
            if (result == 1)
                return false;
            return true;
        }
    }
}
