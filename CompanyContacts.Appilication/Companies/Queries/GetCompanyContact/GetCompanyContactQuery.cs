using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Companies.Queries.GetCompanyContact
{
    public class GetCompanyContactQuery : IRequest<CompanyContactVM>
    {
        public string Id { get; set; }
    }

    public class GetCompanyContactQueryHandler : IRequestHandler<GetCompanyContactQuery , CompanyContactVM>
    {
        private readonly ICompanyRepository _companyRepository;

        public GetCompanyContactQueryHandler(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;
        }

        public Task<CompanyContactVM> Handle(GetCompanyContactQuery request, CancellationToken cancellationToken)
        {
            return _companyRepository.GetCompanyContract(request.Id);
        }
    }
}
