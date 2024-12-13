using OAuthAPI.Models.Entities;

namespace OAuthAPI.Services
{
    public interface IEmployeeService
    {
        IEnumerable<Employee> GetAllEmployees();
        Employee GetEmployeeById(Guid id);
        Employee AddEmployee(Employee employee);
        Employee UpdateEmployee(Guid id, Employee updateEmployee);
        Employee DeleteEmployee(Guid id);
    }
}
