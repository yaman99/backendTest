using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Core.Interfaces
{
    public interface IDatabaseSettings
    {
        string ConnectionString { get; set; }
        string DatabaseName { get; set; }
    }
}
