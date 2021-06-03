using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
  public class EmployeeRepository : IEmployeeRepository
  {
    private readonly DataContext _context;
    public EmployeeRepository(DataContext context)
    {
      _context = context;

    }
    public async Task<Employee> GetEmployeeByIdAsync(int id)
    {
      return await _context.Employees.FirstOrDefaultAsync(x => x.EmplyeeId == id);
    }

    public async Task<IEnumerable<Employee>> GetEmployeesAsync()
    {
      return await _context.Employees.ToListAsync();
    }

    public async Task<bool> SaveAllAsync()
    {
      return await _context.SaveChangesAsync() > 0;
    }

    public void Update(Employee emp)
    {
      _context.Entry(emp).State = EntityState.Modified;
    }

    public void AddEmployee(Employee emp)
    {
      _context.Employees.Add(emp);
    }
  }
}