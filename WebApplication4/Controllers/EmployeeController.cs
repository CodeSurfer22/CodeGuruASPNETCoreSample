using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication4.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApplication4.Controllers
{
    [Route("api/[controller]")]
    public class EmployeeController : Controller
    {
        [HttpGet]
        public List<Employee> Get()
        {
            using (EmployeeDbContext db = new
               EmployeeDbContext())
            {
                return db.Employees.ToList();
            }
        }

        [HttpGet("{id}")]
        public Employee Get(int id)
        {
            using (EmployeeDbContext db = new
               EmployeeDbContext())
            {
                return db.Employees.Find(id);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody]Employee obj)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                db.Employees.Add(obj);
                db.SaveChanges();
                return new ObjectResult("Employee added successfully!");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]Employee obj)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {
                db.Entry<Employee>(obj).State = EntityState.Modified;
                db.SaveChanges();
                return new ObjectResult("Employee modified successfully!");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            using (EmployeeDbContext db = new EmployeeDbContext())
            {

                db.Employees.Remove(db.Employees.Find(id));
                db.SaveChanges();
                return new ObjectResult("Employee deleted successfully!");
            }
        }
    }
}
