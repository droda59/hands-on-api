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
        public async Task<bool> Post([FromBody]Employee value)
        {
            return await this._employeeRepository.InsertAsync(value);
        }

        [HttpPut("{id}")]
        public async Task<bool> Put(string id, [FromBody]Employee value)
        {
            return await this._employeeRepository.UpdateAsync(id, value);
        }

        [HttpDelete("{id}")]
        public async Task<bool> Delete(string id)
        {
            return await this._employeeRepository.DeleteAsync(id);
        }
    }
}
