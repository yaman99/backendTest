using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Companies.Commands.UpdateCompanyContact
{
    public class UpdateComapnyContactCommand : IRequest<Result>
    {
        public string CompanyId { get; set; }
        public ContactVM  Contact { get; set; }
    }

    public class UpdateComapnyContactCommandHandler : IRequestHandler<UpdateComapnyContactCommand, Result>
    {
        private readonly ICompanyRepository _companyRepository;

        public UpdateComapnyContactCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Result> Handle(UpdateComapnyContactCommand request, CancellationToken cancellationToken)
        {
            var result = await _companyRepository.UpdateCompanyContact(request.CompanyId,  request.Contact);
            if (result)
                return Result.Success("Contact Updated Successfully");
            return Result.Failure("SomeThing Wrong");
        }
    }
}
