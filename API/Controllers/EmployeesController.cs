using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.Data;
using API.DTOs;
using API.Entities;
using API.Interfaces;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : BaseApiController
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;

        public EmployeesController(IEmployeeRepository employeeRepository, IMapper mapper)
        {
          _employeeRepository = employeeRepository;
          _mapper = mapper;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDto>>> GetEmployees()
        {
            var emps = await _employeeRepository.GetEmployeesAsync();
            var empsToReturn = _mapper.Map<IEnumerable<EmployeeDto>>(emps);
            return Ok(empsToReturn);          
            
        }

         [HttpGet("{Id}")]
        public async Task<ActionResult<EmployeeDto>> GetEmployee(int id)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(id);
            return _mapper.Map<EmployeeDto>(emp);
            
        }

        [HttpPut]
        public async Task<ActionResult<EmployeeDto>> UpdateEmployee(EmployeeDto employeeDto)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(employeeDto.EmplyeeId);
             _mapper.Map(employeeDto,emp);

             _employeeRepository.Update(emp);
             if(await _employeeRepository.SaveAllAsync()) return NoContent();

             return BadRequest("Failed to update Employee");
            
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeDto>> AddEmployee(EmployeeDto employeeDto)
        {
            var emp = await _employeeRepository.GetEmployeeByIdAsync(employeeDto.EmplyeeId);
            if(emp == null)
            {
                var employee = new Employee
                {
                 EmplyeeId = employeeDto.EmplyeeId,
                 EmployeeName = employeeDto.EmployeeName,
                 EmployeeAddress = employeeDto.EmployeeAddress,
                 Position = employeeDto.Position,
                 PhoneNumber = employeeDto.PhoneNumber
                };

                _employeeRepository.AddEmployee(employee);
                if(await _employeeRepository.SaveAllAsync()) return Ok(_mapper.Map<EmployeeDto>(employee));

            }

            return BadRequest("Employee already exist");                  
            
        }
        
    }
}