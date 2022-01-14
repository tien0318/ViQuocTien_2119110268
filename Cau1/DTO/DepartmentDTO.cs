using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DTO
{
    class DepartmentDTO
    {
        public string IdDepartment { get; set; }
        public string NameDep { get; set; }
        public List<EmployeeDTO> employees { get; set; }
    }
}
