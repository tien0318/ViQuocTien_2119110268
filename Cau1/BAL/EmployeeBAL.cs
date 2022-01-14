using Cau1.DAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    class EmployeeBAL
    {
        EmployeeDAL dal = new EmployeeDAL();
        public List<EmployeeDTO> ReadEmployee()
        {
            List<EmployeeDTO> lstEmp = dal.ReadEmployee();
            return lstEmp;
        }
        public void NewEmployee(EmployeeDTO emp)
        {
            dal.NewEmployee(emp);
        }
        public void DeleteEmployee(EmployeeDTO emp)
        {
            dal.DeleteEmployee(emp);
        }
        public void EditEmployee(EmployeeDTO emp)
        {
            dal.EditEmployee(emp);
        }
    }
}
