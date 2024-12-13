using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OAuthAPI.Models.Entities;
using OAuthAPI.Services;

namespace OAuthAPI.Controllers
{
    //localhost:xxxx/api/Employees
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        private readonly IEmployeeService _employeeService;

        public EmployeesController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }
        [HttpGet(Name = "Get all Employees"), Authorize(Roles = "Admin")]
        public IActionResult GetAllEmployees()
        {
            var employees = _employeeService.GetAllEmployees();
            return Ok(employees);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetEmployeeById(Guid id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }
            return Ok(employee);
        }

        [HttpPost]
        public IActionResult AddEmployee(AddEmployeeDto addEmployeeDto)
        {
            var newEmployee = new Employee
            {
                Name = addEmployeeDto.Name,
                Email = addEmployeeDto.Email,
                Phone = addEmployeeDto.Phone,
                Salary = addEmployeeDto.Salary
            };

            var addedEmployee = _employeeService.AddEmployee(newEmployee);
            return CreatedAtAction(nameof(GetEmployeeById), new { id = addedEmployee.Id }, addedEmployee);
        }

        [HttpPut("{id:guid}")]
        public IActionResult UpdateEmployee(Guid id, UpdateEmployeeDto updateEmployeeDto)
        {
            var updatedEmployee = new Employee
            {
                Name = updateEmployeeDto.Name,
                Email = updateEmployeeDto.Email,
                Phone = updateEmployeeDto.Phone,
                Salary = updateEmployeeDto.Salary
            };

            var employee = _employeeService.UpdateEmployee(id, updatedEmployee);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(employee);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult DeleteEmployee(Guid id)
        {
            var employee = _employeeService.DeleteEmployee(id);
            if (employee == null)
            {
                return NotFound($"Employee with ID {id} not found.");
            }

            return Ok(employee);
        }
    }
}
