using HandsOnApi.Models;

namespace HandsOnApi.Repositories
{
    internal class EmployeeRepository : MongoDBRepository<Employee>, IEmployeeRepository
    {
    }
}
