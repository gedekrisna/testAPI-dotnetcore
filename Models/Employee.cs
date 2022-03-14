using System.ComponentModel.DataAnnotations;

namespace test.Models
{
    public class Employee
    {
        [Key]
        public int? Id { get; set; }
        public string Nama { get; set; } 
        public string Alamat { get; set; } 
    }
}