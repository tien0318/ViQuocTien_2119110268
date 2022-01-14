using Cau1.DAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.BAL
{
    class DepartmentiBAL
    {
        DepartmentDAL dal = new DepartmentDAL();
        public  List<DepartmentDTO> ReadDepartmentList()
        {

            List<DepartmentDTO> lstDepartment = dal.ReadDepartmentList();
            return lstDepartment;
        }
    }
}
