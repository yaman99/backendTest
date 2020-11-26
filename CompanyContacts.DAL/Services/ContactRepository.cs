using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Interfaces;
using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.DAL.Common;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyContacts.DAL.Services
{
    public class ContactRepository : IContactRepository
    {
        private readonly IDbContext _context = null;

        public ContactRepository(IOptions<DatabaseSettings> settings)
        {
            _context = new DbContext(settings);
        }

        public async Task<bool> AddContact(Contact contact)
        {
            await _context.Contact.InsertOneAsync(contact);
            return true;
        }

        public Task<bool> DeleteContact(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await _context.Contact.Find(_ => true).ToListAsync();
        }

        public bool IsUserExist(string Name)
        {
            var result = _context.Contact.Find(x => x.Name == Name).CountDocuments();
            if (result == 1)
                return false;
            return true;
        }

        public Task<bool> UpdateContact(string id)
        {
            throw new NotImplementedException();
        }
    }
}
