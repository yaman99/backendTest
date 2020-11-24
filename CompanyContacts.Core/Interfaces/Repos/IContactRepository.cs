using CompanyContacts.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CompanyContacts.Core.Interfaces.Repos
{
    public interface IContactRepository
    {
        Task<bool> AddContact(Contact contact);
        Task<IEnumerable<Contact>> GetContacts();
        Task<bool> UpdateContact(string id);
        Task<bool> DeleteContact(string id);
    }
}
