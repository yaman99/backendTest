using CompanyContacts.Appilication.Companies.Commands.DeleteCompany;
using CompanyContacts.Appilication.Companies.Commands.DeleteCompanyContact;
using CompanyContacts.Appilication.Companies.Commands.InsertCompany;
using CompanyContacts.Appilication.Companies.Commands.UpdateCompanyContact;
using CompanyContacts.Appilication.Companies.Queries.GetAllCompanies;
using CompanyContacts.Appilication.Companies.Queries.GetCompanyContact;
using CompanyContacts.Core.Entities;
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
                return Ok(result);
            return BadRequest(result);
        }

        [HttpGet("GetCompanies")]
        public async Task<IEnumerable<Company>> GetAllCompanies()
        {
            return await Mediator.Send(new GetCompaniesQuery());

        }

        [HttpGet("GetCompanyContact/{companyId}")]
        public async Task<CompanyContactVM> GetCompanyContact(string companyId)
        {
            return await Mediator.Send(new GetCompanyContactQuery { Id = companyId});
        }

        [HttpPut("UpdateComapnyContact")]
        public async Task<ActionResult<Result>> GetCompanyContact(UpdateComapnyContactCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }

        [HttpDelete("DeleteCompany/{id}")]
        public async Task<ActionResult<Result>> DeleteCompany(string id)
        {
            return await Mediator.Send(new DeleteCompanyCommand { ComapnyId = id });

        }

        [HttpDelete("DeleteCompanyContact")]
        public async Task<ActionResult<Result>> DeleteCompanyContact(DeleteCompanyContactCommand command)
        {
            var result = await Mediator.Send(command);

            if (result.IsSuccessed)
                return Ok(result);
            return BadRequest(result);
        }
    }
}
