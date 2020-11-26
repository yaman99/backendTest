using CompanyContacts.Core.Interfaces.Repos;
using FluentValidation;
using FluentValidation.Validators;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Appilication.Companies.Commands.InsertCompany
{
    public class InsertCompanyValidator : AbstractValidator<InsertCompanyCommand>
    {
        private readonly ICompanyRepository _companyRepository;

        public InsertCompanyValidator(ICompanyRepository companyRepository)
        {
            _companyRepository = companyRepository;

            RuleFor(x => x.Name).Must(IsUserExistValidator)
                .WithMessage("This Name Exist Use another Name");
        }

        private bool IsUserExistValidator(string nameValue)
        {
            return _companyRepository.IsUserExist(nameValue);
        }
    }

}
