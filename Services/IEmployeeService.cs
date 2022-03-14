using test.Models;  
using System.Collections.Generic;  
  
namespace test.Service  
{  
    public interface IEmployeeService  
    {  
  
        Employee AddEmployee(Employee employee);  
  
        List<Employee> GetEmployees();  
  
        void UpdateEmployee(Employee employee);  
  
        void DeleteEmployee(int id);  
  
        Employee GetEmployee(int id);  
    }  
}