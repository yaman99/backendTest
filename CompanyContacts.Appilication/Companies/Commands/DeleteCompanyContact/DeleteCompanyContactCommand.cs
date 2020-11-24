using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Companies.Commands.DeleteCompanyContact
{
    public class DeleteCompanyContactCommand : IRequest<Result>
    {
        public string CompanyId { get; set; }
        public string ContactId { get; set; }
    }
    public class DeleteCompanyContactCommandHandler : IRequestHandler<DeleteCompanyContactCommand ,Result>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyContactCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Result> Handle(DeleteCompanyContactCommand request, CancellationToken cancellationToken)
        {
            var result =  await _companyRepository.DeleteCompanyContact(request.ContactId, request.CompanyId);
            if (result)
                return Result.Success("CompanyContact Deleted");
            return Result.Failure("SomeThing Wrong");
        }
    }
}
