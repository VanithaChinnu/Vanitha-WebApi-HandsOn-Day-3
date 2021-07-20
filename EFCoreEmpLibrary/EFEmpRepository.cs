using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreEmpLibrary
{
    public class EFEmpRepository : IEmpRepository {
        ADM21DF004Context dc = new ADM21DF004Context();
        public async Task DeleteEmployee(int eid) {
            Task<EMPL> emp2delete = GetEmployeeById(eid);
            EMPL emp2del = emp2delete.Result;
            dc.EMPLs.Remove(emp2del);
            await dc.SaveChangesAsync();
        }
        public async Task<List<EMPL>> GetAllEmployees() {
            return await dc.EMPLs.ToListAsync();
        }
        public async Task<EMPL> GetEmployeeById(int eid) {
            try {
                Task<EMPL> emp = (from e in dc.EMPLs where e.EID == eid select e).FirstAsync();
                return await emp;
            }
            catch (Exception) {
                throw new EmpException("No such emp id");
            }
        }
        public async Task InsertEmployee(EMPL emp) {
            dc.EMPLs.Add(emp);
            await dc.SaveChangesAsync();
        }
        public async Task UpdateEmployee(int eid, EMPL emp) {
            Task<EMPL> emp2update = GetEmployeeById(eid);
            EMPL emp2edit = emp2update.Result;
            emp2edit.EmpName = emp.EmpName;
            emp2edit.DoBirth = emp.DoBirth;
            emp2edit.Salary = emp.Salary;
            await dc.SaveChangesAsync();
        }
    }
}
