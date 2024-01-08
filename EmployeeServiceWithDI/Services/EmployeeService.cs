namespace EmployeeServiceWithDI.Services
{
    using EmployeeServiceWithDI.Models;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class EmployeeService : IEmployeeService
    {
        private readonly List<Employee> _employees;

        public EmployeeService()
        {
            _employees = new List<Employee>
        {
            new Employee { Id = 1, FirstName = "John", LastName = "Doe", Position = "Developer" },
            new Employee { Id = 2, FirstName = "Jane", LastName = "Smith", Position = "QA" },
            new Employee { Id = 3, FirstName = "Bob", LastName = "Johnson", Position = "Manager" }
        };
        }

        public Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            return Task.FromResult<IEnumerable<Employee>>(_employees);
        }

        public Task<Employee> GetEmployeeByIdAsync(int id)
        {
            return Task.FromResult(_employees.FirstOrDefault(e => e.Id == id));
        }

        public Task AddEmployeeAsync(Employee employee)
        {
            return Task.Run(() => AddEmployee(employee));
        }

        public Task UpdateEmployeeAsync(int id, Employee employee)
        {
            return Task.Run(() => UpdateEmployee(id, employee));
        }

        public Task DeleteEmployeeAsync(int id)
        {
            return Task.Run(() => DeleteEmployee(id));
        }

        private void AddEmployee(Employee employee)
        {
            employee.Id = _employees.Max(e => e.Id) + 1;
            _employees.Add(employee);
        }

        private void UpdateEmployee(int id, Employee employee)
        {
            var existingEmployee = _employees.FirstOrDefault(e => e.Id == id);
            if (existingEmployee != null)
            {
                existingEmployee.FirstName = employee.FirstName;
                existingEmployee.LastName = employee.LastName;
                existingEmployee.Position = employee.Position;
            }
        }

        private void DeleteEmployee(int id)
        {
            var employeeToRemove = _employees.FirstOrDefault(e => e.Id == id);
            if (employeeToRemove != null)
            {
                _employees.Remove(employeeToRemove);
            }
        }
    }


}
