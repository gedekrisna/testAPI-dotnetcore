using test.Models;  
using System.Collections.Generic;  
using System.Linq;
using test.Data;

namespace test.Service  
{  
    public class EmployeeService : IEmployeeService  
    {  
        public MyDBContext _employeeDbContext;  
        public EmployeeService(MyDBContext employeeDbContext)  
        {  
            _employeeDbContext = employeeDbContext;  
        }  
        public Employee AddEmployee(Employee employee)  
        {  
            _employeeDbContext.Employees.Add(employee);  
            _employeeDbContext.SaveChanges();  
            return employee;  
        }  
        public List<Employee> GetEmployees()  
        {  
            return _employeeDbContext.Employees.ToList();  
        }  
  
        public void UpdateEmployee(Employee employee)  
        {  
            _employeeDbContext.Employees.Update(employee);  
            _employeeDbContext.SaveChanges();  
        }  
  
        public void DeleteEmployee(int Id)
        {
            var employee = _employeeDbContext.Employees.FirstOrDefault(x => x.id == Id);
            if (employee != null)  
            {  
                _employeeDbContext.Remove(employee);  
                _employeeDbContext.SaveChanges();  
            }  
        }  
  
        public Employee GetEmployee(int Id)  
        {  
            return _employeeDbContext.Employees.FirstOrDefault(x => x.id == Id);  
        }  
  
    }  
}