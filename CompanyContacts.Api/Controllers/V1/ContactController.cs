using CompanyContacts.Appilication.Contacts.Commands.InsertContact;
using CompanyContacts.Appilication.Contacts.Commands.Queries.GetContact;
using CompanyContacts.Core.Entities;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyContacts.Api.Controllers.V1
{
    public class ContactController : ApiController
    {
        [HttpPost("AddContact")]
        public async Task<ActionResult> AddContact(InsertContactCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetContacts")]
        public async Task<IEnumerable<Contact>> GetContacts()
        {
            return await Mediator.Send(new GetContactQuery());
        }
    }
}
