using test.Models;  
using System.Collections.Generic;  
  
namespace test.Service  
{  
    public interface IEmployeeService  
    {  
  
        Employee AddEmployee(Employee employee);  
  
        List<Employee> GetEmployees();  
  
        void UpdateEmployee(Employee employee);  
  
        void DeleteEmployee(int Id);  
  
        Employee GetEmployee(int Id);  
    }  
}