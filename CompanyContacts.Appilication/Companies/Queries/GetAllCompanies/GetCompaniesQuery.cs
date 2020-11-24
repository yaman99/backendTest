using CompanyContacts.Core.Entities;
using CompanyContacts.Core.Interfaces.Repos;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Companies.Queries.GetAllCompanies
{
    public class GetCompaniesQuery : IRequest<IEnumerable<Company>>
    {
    }

    public class GetAllCompaniesQueryHandler : IRequestHandler<GetCompaniesQuery , IEnumerable<Company>>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetAllCompaniesQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public async Task<IEnumerable<Company>> Handle(GetCompaniesQuery request, CancellationToken cancellationToken)
        {
            return await _companyRepository.GetAllCompanies();
        }
    }
}
