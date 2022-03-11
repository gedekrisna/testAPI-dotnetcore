using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using test.Data;
using test.Models;

namespace test.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private MyDBContext myDbContext;  
  
        public EmployeeController(MyDBContext context)  
        {  
            myDbContext = context;  
        }  
  
        [HttpGet]  
        public IList<Employee> Get()
        {
            return (this.myDbContext.Employees.AsNoTracking().ToList());
            
        }  
        
        [HttpGet("{id}")]
        public List<Employee> GetbyId(int id)
        {
            return new List<Employee>()
            {
                myDbContext.Employees.FirstOrDefault(x => x.id == id)
            };
            
        }  
        
        [HttpPost]  
        public IList<Employee> Post([FromBody] Employee param)
        {
            myDbContext.Employees.Add(param);
            myDbContext.SaveChanges();
            
            return (this.myDbContext.Employees.AsNoTracking().ToList());
            
        } 

        [HttpPut("{id}")]
        public IList<Employee> Update(int id, [FromBody] Employee param)
        {
            myDbContext.Entry(param).State = EntityState.Modified;  
            myDbContext.SaveChanges();
            // myDbContext.Entry(await myDbContext.Employees.FirstOrDefaultAsync(x => x.id == param.id)).CurrentValues.SetValues(param);
            return (this.myDbContext.Employees.AsNoTracking().ToList());
        }
        
        // [HttpDelete("{id}")]
        // public IList<Employee> Delete(int id)
        // {
        //     if (id <= 0)
        //         return BadRequest("id Tidak Valid");
        //
        //     using (var ctx = myDbContext)
        //     {
        //         var employee = ctx.Employees
        //             .FirstOrDefault(x => x.id == id);
        //
        //         ctx.Entry(employee).State = 
        //             System.Data..EntityState.Deleted;
        //         ctx.SaveChanges();
        //     }
        //     
        //     return (this.myDbContext.Employees.AsNoTracking().ToList());
        //
        // }
        
        
        
        // // PUT: api/Employee/5
        // [HttpPut("{id}")]
        // public List<Employee> Put(int id, [FromBody] Employee param)
        // {
        
        //     myDbContext.Employees.Add(param);
        //     myDbContext.SaveChanges();
        //     return (this.myDbContext.Employees.AsNoTracking().ToList());
        // }
        
        
        
        // [HttpDelete]
        // public IList<Employee> Delete([FromBody] Employee param)
        // {
        //     // [HttpDelete]
        //     // public async Task<IActionResult> Delete([FromBody]EntityViewModel vm)
        //     // {
        //     myDbContext.Employees.FirstOrDefault().
        //     myDbContext.SaveChanges();
            
        //     return (this.myDbContext.Employees.AsNoTracking().ToList());

        // }
        
        // // GET: api/Employee
        // [HttpGet]
        // public IEnumerable<string> Get()
        // {
        //     return new string[] { "value1", "value2" };
        // }
        //
        // // GET: api/Employee/5
        // [HttpGet("{id}", Name = "Get")]
        // public string Get(int id)
        // {
        //     return "value";
        // }
        //
        // // POST: api/Employee
        // [HttpPost]
        // public void Post([FromBody] string value)
        // {
        // }
        //
        // // PUT: api/Employee/5
        // [HttpPut("{id}")]
        // public void Put(int id, [FromBody] string value)
        // {
        // }
        //
        // // DELETE: api/ApiWithActions/5
        // [HttpDelete("{id}")]
        // public void Delete(int id)
        // {
        // }
    }
}
