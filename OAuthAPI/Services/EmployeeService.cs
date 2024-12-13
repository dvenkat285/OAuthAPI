using OAuthAPI.Data;
using OAuthAPI.Models.Entities;
using System;

namespace OAuthAPI.Services
{ 
    public class EmployeeService : IEmployeeService
    {
        private readonly ApplicationDbContext _dbContext;

        public EmployeeService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<Employee> GetAllEmployees()
        {
            return _dbContext.Employees.ToList();
        }

        public Employee GetEmployeeById(Guid id)
        {
            return _dbContext.Employees.Find(id);
        }

        public Employee AddEmployee(Employee employee)
        {
            _dbContext.Employees.Add(employee);
            _dbContext.SaveChanges();
            return employee;
        }
        public Employee UpdateEmployee(Guid id, Employee updateEmployee)
        {
            var existingEmployee = _dbContext.Employees.Find(id);
            if (existingEmployee == null)
            {
                return null;
            }
            existingEmployee.Name = updateEmployee.Name;
            existingEmployee.Email = updateEmployee.Email;
            existingEmployee.Phone = updateEmployee.Phone;
            existingEmployee.Salary = updateEmployee.Salary;

            _dbContext.SaveChanges();
            return existingEmployee;
        }
        public Employee DeleteEmployee(Guid id)
        {
            var employee = _dbContext.Employees.Find(id);
            if (employee != null)
            {
                _dbContext.Employees.Remove(employee);
                _dbContext.SaveChanges();
            }
            return employee;
        }

    }
}
