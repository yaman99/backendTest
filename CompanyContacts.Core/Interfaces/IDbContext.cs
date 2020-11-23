using CompanyContacts.Core.Entities;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Core.Interfaces
{
    public interface IDbContext
    {
        IMongoCollection<Company> Company { get; }
    }
}
