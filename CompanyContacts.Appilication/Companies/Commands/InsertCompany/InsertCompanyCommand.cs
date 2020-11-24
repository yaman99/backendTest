using CompanyContacts.Core.Interfaces.Repos;
using CompanyContacts.Core.Models;
using CompanyContacts.Core.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CompanyContacts.Appilication.Companies.Commands.InsertCompany
{
    public class InsertCompanyCommand : IRequest<Result>
    {
        public string Name { get; set; }
        public int NumOfEmployees { get; set; }
    }

    public class InsertCompanyCommandHandler : IRequestHandler<InsertCompanyCommand , Result>
    {
        private readonly ICompanyRepository _companyRepository;

        public InsertCompanyCommandHandler(ICompanyRepository company)
        {
            _companyRepository = company;
        }

        public async Task<Result> Handle(InsertCompanyCommand request, CancellationToken cancellationToken)
        {
            var company = new Company
            {
                Name = request.Name,
                NumOfEmployees = request.NumOfEmployees
            };

            var result = await _companyRepository.AddCompany(company);

            if (result)
                return Result.Success("Company Inserted");
            return Result.Failure("SomeThing Wrong");
        }
    }
}
