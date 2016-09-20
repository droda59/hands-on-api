using System.Collections.Generic;
using System.Threading.Tasks;

using HandsOnApi.Models;

namespace HandsOnApi.Repositories
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<Employee>> GetAsync();

        Task<Employee> GetAsync(string id);

        Task<bool> UpdateAsync(string id, Employee data);

        Task<bool> InsertAsync(Employee data);

        Task<bool> DeleteAsync(string id);
    }
}
