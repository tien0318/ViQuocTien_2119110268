using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DTO
{
    class EmployeeDTO
    {
        public string Id { get; set; }
        public string tenNV { get; set; }
        public string Noisinh { get; set; }
        public DateTime ngaysinh { get; set; }
        public int gioitinh { get; set; }
        public DepartmentDTO Donvi { get; set; }
        public string DepartmenntName {

            get { return Donvi.NameDep; } 
        }
      
    }
}
