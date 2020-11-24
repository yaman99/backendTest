using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Companies.Commands.DeleteCompany
{
    public class DeleteCompanyCommand : IRequest<Result>
    {
        public string ComapnyId { get; set; }
    }

    public class DeleteCompanyCommandHandler : IRequestHandler<DeleteCompanyCommand, Result>
    {
        private readonly ICompanyRepository _companyRepository;

        public DeleteCompanyCommandHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<Result> Handle(DeleteCompanyCommand request, CancellationToken cancellationToken)
        {
            var result = await _companyRepository.removeCompany(request.ComapnyId);
            if (result)
                return Result.Success("Company Deleted");
            return Result.Failure("SomeThing Wrong");
        }
    }
}
