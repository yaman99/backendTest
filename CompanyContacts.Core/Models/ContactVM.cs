﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Core.Models
{
    public class ContactVM
    {
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Name { get; set; }
        [BsonExtraElements]
        [BsonIgnoreIfNull]
        public Dictionary<string, Object> OtherData { get; set; }
    }
}
