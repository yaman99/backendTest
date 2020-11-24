using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Interfaces.Repos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Contacts.Commands.Queries.GetContact
{
    public class GetContactQuery : IRequest<IEnumerable<Contact>>
    {
    }

    public class GetContactQueryHandler : IRequestHandler<GetContactQuery, IEnumerable<Contact>>
    {
        private readonly IContactRepository _contactRepository;

        public GetContactQueryHandler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
        }

        public async Task<IEnumerable<Contact>> Handle(GetContactQuery request, CancellationToken cancellationToken)
        {
            return await _contactRepository.GetContacts();
        }
    }
}
