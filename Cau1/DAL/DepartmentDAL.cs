using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{
    class DepartmentDAL:DBConnection
    {
        public List<DepartmentDTO> ReadDepartmentList()
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from Department_2119110268", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<DepartmentDTO> lstDep = new List<DepartmentDTO>();
            while (reader.Read())
            {
                DepartmentDTO dep = new DepartmentDTO();
                dep.IdDepartment = reader["IdDepartment"].ToString();
                dep.NameDep = reader["NameDep"].ToString();
                lstDep.Add(dep);
            }
            conn.Close();
            return lstDep;
        }
        public DepartmentDTO ReadDepartment(string id)
        {
            SqlConnection conn = CreateConnection();
            conn.Open();
            SqlCommand cmd = new SqlCommand(
                "select * from Department_2119110268 where IdDepartment = '" + id.ToString() + "'", conn);
            SqlDataReader reader = cmd.ExecuteReader();
            DepartmentDTO dep = new DepartmentDTO();
            if (reader.HasRows && reader.Read())
            {
                dep.IdDepartment = reader["IdDepartment"].ToString();
                dep.NameDep = reader["NameDep"].ToString();
            }
            conn.Close();
            return dep;
        }
    }
}
