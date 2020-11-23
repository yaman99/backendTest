using CompanyContacts.Appilication.Companies.Commands.InsertCompany;
using CompanyContacts.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CompanyContacts.Api.Controllers.V1
{
    public class CompanyController : ApiController
    {
        [HttpPost("AddCompany")]
        public async Task<ActionResult<Result>> AddCompany([FromBody] InsertCompanyCommand command)
        {
            var result =  await Mediator.Send(command);

            if (result.IsSuccessed)
                return Ok(result.Message);
            return BadRequest(result.Message);
        }
    }
}
