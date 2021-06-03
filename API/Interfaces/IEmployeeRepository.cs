using System.Collections.Generic;
using System.Threading.Tasks;
using API.Entities;

namespace API.Interfaces
{
    public interface IEmployeeRepository
    {
     void Update(Employee emp);
     Task<bool> SaveAllAsync();

     Task<Employee> GetEmployeeByIdAsync(int Id);

     Task<IEnumerable<Employee>> GetEmployeesAsync();

     void AddEmployee(Employee employee);
    }
}