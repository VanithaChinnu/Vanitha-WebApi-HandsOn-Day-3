using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreEmpLibrary;
namespace EmpWebApi.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase {
        IEmpRepository empRep;
        public EmployeeController(IEmpRepository ier) {
            empRep = ier;
        }
        [HttpGet]
        public ActionResult<List<EMPL>> GetAll() {
            return Ok(empRep.GetAllEmployees());
        }
        [HttpGet("{id}")]
        public ActionResult<EMPL> GetOne(int id) {
            try {
                return Ok(empRep.GetEmployeeById(id));
            }
            catch(EmpException ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        public ActionResult Insert(EMPL emp) {
            empRep.InsertEmployee(emp);
            return Created($"api/Employee/{emp.EID}", emp);
        }
        [HttpPut("{id}")]
        public ActionResult Update(int id, EMPL emp) {
            empRep.UpdateEmployee(id, emp);
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        public ActionResult Delete(int id) {
            empRep.DeleteEmployee(id);
            return Ok();
        }
    }
}
