using AutoMapper;
using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.Core.Models;
using MediatR;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Contacts.Commands.InsertContact
{
    public class InsertContactCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public List<Company> Companies { get; set; }
    }

    public class InsertContactCommandHandler : IRequestHandler<InsertContactCommand, Result>
    {
        private readonly IContactRepository _contactRepository;

        public InsertContactCommandHandler(IContactRepository contactRepository, IMapper mapper)
        {
            _contactRepository = contactRepository;
        }

        public async Task<Result> Handle(InsertContactCommand request, CancellationToken cancellationToken)
        {           
            var contact = new Contact
            {
                Name = request.Name,
                Companies= request.Companies
            };

            var result = await _contactRepository.AddContact(contact);
            if (result)
                return Result.Success("Contact Inserted Successfully");
            return Result.Failure("SomeThing Wrong");
        }
    }
}
