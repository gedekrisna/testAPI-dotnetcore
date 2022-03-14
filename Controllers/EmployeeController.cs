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
        // private MyDBContext myDbContext;  
        //
        // public EmployeeController(MyDBContext context)  
        // {  
        //     myDbContext = context;  
        // }  
        private readonly EmployeeContext _context;

        public EmployeeController(EmployeeContext context)
        {
            _context = context;
        }
        
        [HttpGet]  
        public async Task<ActionResult<ResponseDto>> GetEmployee()
        {
            var data =  await _context.Employees
                .AsNoTracking().ToListAsync();

            return new ResponseDto()
            {
                Status = true,
                Message = "Sukses",
                Data = data
            };
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetbyId(int id)
        {
            var getDataEmployee = await _context.Employees.FindAsync(id);

            if (getDataEmployee == null)
            {
                return NotFound();
            }

            return getDataEmployee;
        }
        
        [HttpPost]
        public async Task<List<Employee>> CreateTodoItem(Employee param)
        {
            var dataEmployee = new Employee
            {
                Nama = param.Nama,
                Alamat = param.Alamat
            };

            _context.Employees.Add(dataEmployee);
            await _context.SaveChangesAsync();
            
            return (this._context.Employees.AsNoTracking().ToList());
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Put(int id, Employee param)
        {
            if (id != param.Id)
            {
                return BadRequest();
            }

            var dataEmployee = await _context.Employees.FindAsync(id);
            if (dataEmployee == null)
            {
                return NotFound();
            }

            dataEmployee.Nama = param.Nama;
            dataEmployee.Alamat = param.Alamat;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) when (!EmployeeExists(id))
            {
                return NotFound();
            }

            return NoContent();
        }
        
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var dataEmployee = await _context.Employees.FindAsync(id);

            if (dataEmployee == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(dataEmployee);
            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        private bool EmployeeExists(int id) =>
            _context.Employees.Any(e => e.Id == id);
    }
}
