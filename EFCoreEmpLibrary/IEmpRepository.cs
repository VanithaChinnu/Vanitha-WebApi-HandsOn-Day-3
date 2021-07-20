using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreEmpLibrary
{
        public interface IEmpRepository
        {
            Task<List<EMPL>> GetAllEmployees();
            Task<EMPL> GetEmployeeById(int eid);
            Task InsertEmployee(EMPL emp);
            Task UpdateEmployee(int eid, EMPL emp);
            Task DeleteEmployee(int eid);
        }
}
