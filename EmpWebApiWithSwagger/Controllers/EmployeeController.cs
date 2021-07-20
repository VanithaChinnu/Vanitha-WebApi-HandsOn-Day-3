using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EFCoreEmpLibrary;
using Microsoft.AspNetCore.Authorization;

namespace EmpWebApiWithSwagger.Controllers { 
    [Route("api/[controller]")]
    [ApiController]

    public class EmployeeController : ControllerBase {
        IEmpRepository empRep;
        public EmployeeController(IEmpRepository ier) {
            empRep = ier;
        }
        [Authorize(Roles = "Admins")]
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<EMPL>>> GetAll() {
            return Ok(await empRep.GetAllEmployees());
        }
        [Authorize(Roles = "POC")]
        [HttpGet("{id}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<EMPL>> GetOne(int id) {
            try {
                return Ok(await empRep.GetEmployeeById(id));
            }
            catch (EmpException ex) {
                return NotFound(ex.Message);
            }
        }
        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> Insert(EMPL emp) {
            await empRep.InsertEmployee(emp);
            return Created($"api/Employee/{emp.EID}", emp);
        }
        [HttpPut("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Update(int id, EMPL emp) {
            await empRep.UpdateEmployee(id, emp);
            return Ok(emp);
        }
        [HttpDelete("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> Delete(int id) {
            await empRep.DeleteEmployee(id);
            return Ok();
        }
    }
}
