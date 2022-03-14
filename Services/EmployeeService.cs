using test.Models;  
using System.Collections.Generic;  
using System.Linq;
using test.Data;

namespace test.Service  
{  
    public class EmployeeService : IEmployeeService  
    {  
        public MyDbContext EmployeeDbContext;  
        public EmployeeService(MyDbContext employeeDbContext)  
        {  
            EmployeeDbContext = employeeDbContext;  
        }  
        public Employee AddEmployee(Employee employee)  
        {  
            EmployeeDbContext.Employees.Add(employee);  
            EmployeeDbContext.SaveChanges();  
            return employee;  
        }  
        public List<Employee> GetEmployees()  
        {  
            return EmployeeDbContext.Employees.ToList();  
        }  
  
        public void UpdateEmployee(Employee employee)  
        {  
            EmployeeDbContext.Employees.Update(employee);  
            EmployeeDbContext.SaveChanges();  
        }  
  
        public void DeleteEmployee(int id)
        {
            var employee = EmployeeDbContext.Employees.FirstOrDefault(x => x.Id == id);
            if (employee != null)  
            {  
                EmployeeDbContext.Remove(employee);  
                EmployeeDbContext.SaveChanges();  
            }  
        }  
  
        public Employee GetEmployee(int id)  
        {  
            return EmployeeDbContext.Employees.FirstOrDefault(x => x.Id == id);  
        }  
  
    }  
}