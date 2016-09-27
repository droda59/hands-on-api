using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;

using HandsOnApi.Models;
using HandsOnApi.Repositories;

namespace HandsOnApi.Controllers
{
    [Route("api/[controller]")]
    public class EmployeesController : Controller
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeesController(IEmployeeRepository employeeRepository)
        {
            this._employeeRepository = employeeRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Employee>> Get()
        {
            return await this._employeeRepository.GetAsync();
        }

        [HttpGet("{id}")]
        public async Task<Employee> Get(string id)
        {
            return await this._employeeRepository.GetAsync(id);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]Employee value)
        {
            if (value.PhoneNumbers.Count() > 2)
            {
                this.ModelState.AddModelError("PhoneNumber", "Too many phone numbers");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                await this._employeeRepository.InsertAsync(value);

                return this.Ok();
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(string id, [FromBody]Employee value)
        {
            if (value.PhoneNumbers.Count() > 2)
            {
                this.ModelState.AddModelError("PhoneNumber", "Too many phone numbers");
            }

            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = await this._employeeRepository.UpdateAsync(id, value);
                if (result) 
                {
                    return this.Ok();
                }
                else 
                {
                    return this.BadRequest();
                }
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!this.ModelState.IsValid)
            {
                return this.BadRequest(this.ModelState);
            }
            else
            {
                var result = await this._employeeRepository.DeleteAsync(id);
                if (result) 
                {
                    return this.Ok();
                }
                else 
                {
                    return this.BadRequest();
                }
            }
        }
    }
}
