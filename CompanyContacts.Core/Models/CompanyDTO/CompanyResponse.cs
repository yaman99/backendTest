using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Core.Models.CompanyDTO
{
    public class CompanyResponse
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
    }
}
