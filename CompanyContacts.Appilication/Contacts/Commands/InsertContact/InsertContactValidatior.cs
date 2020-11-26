using CompanyContacts.Core.Interfaces.Repos;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace CompanyContacts.Appilication.Contacts.Commands.InsertContact
{
    public class InsertContactValidatior : AbstractValidator<InsertContactCommand>
    {
        private readonly IContactRepository _contactRepository;

        public InsertContactValidatior(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;
            RuleFor(x => x.Name).Must(IsUserExistValidator).WithMessage("This Name Exist Use another Name");

        }

        private bool IsUserExistValidator(string nameValue)
        {
            return _contactRepository.IsUserExist(nameValue);
        }
    }
}
