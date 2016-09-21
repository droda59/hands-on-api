using System.Collections.Generic;
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
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
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
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
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
            if (!ModelState.IsValid)
            {
                return this.BadRequest(ModelState);
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
