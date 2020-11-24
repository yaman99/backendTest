using CompanyContacts.Core.Entities;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Core.Models
{
    public class CompanyContactVM
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
        public List<ContactVM> Contact{ get; set; }
    }
}
