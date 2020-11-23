using CompanyContacts.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.DAL.Common
{
    public class DatabaseSettings : IDatabaseSettings
    {
        public string ConnectionString { get; set ; }
        public string DatabaseName { get; set ; }
    }
}
