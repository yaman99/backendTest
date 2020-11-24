using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.DAL.Common
{
    public class DbContext : IDbContext
    {
        private readonly IMongoDatabase _database = null;

        public DbContext(IOptions<DatabaseSettings> options)
        {
            var clinet = new MongoClient(options.Value.ConnectionString);
            if(clinet != null)
                _database = clinet.GetDatabase(options.Value.DatabaseName);
        }

        public IMongoCollection<Company> Company
        {
            get
            {
                return _database.GetCollection<Company>("Company");
            }
        }
        public IMongoCollection<Contact> Contact
        {
            get
            {
                return _database.GetCollection<Contact>("Contact");
            }
        }
    }
}
