using Cau1.BAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cau1.DAL
{

        class EmployeeDAL : DBConnection
        {
            public EmployeeDAL() : base()
            {

            }
            public List<EmployeeDTO> ReadEmployee()
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("getallEmployee", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = cmd.ExecuteReader();
                List<EmployeeDTO> lstEmp = new List<EmployeeDTO>();
                DepartmentDAL dep = new DepartmentDAL();
                while (reader.Read())
                {
                EmployeeDTO emp = new EmployeeDTO();
                    emp.Id = reader["IdEmployee"].ToString();
                    emp.tenNV = reader["NameEmp"].ToString();
                    emp.Donvi = dep.ReadDepartment(reader["IdDepartment"].ToString());
                    emp.Noisinh = reader["PlaceBirth"].ToString();
                    emp.ngaysinh = Convert.ToDateTime(reader["DateBirth"].ToString());
                    emp.gioitinh = int.Parse(reader["Gender"].ToString());
                    lstEmp.Add(emp);
                }
                conn.Close();
                return lstEmp;
            }
            public void DeleteEmployee(EmployeeDTO emp)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand("delete from Employee_2119110268 where IdEmployee = @IdEmployee", conn);
                cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.Id));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            public void NewEmployee(EmployeeDTO emp)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "insert into Employee_2119110268(IdEmployee,NameEmp,IdDepartment,PlaceBirth,DateBirth,Gender) values(@IdEmployee,@NameEmp,@IdDepartment,@PlaceBirth,@DateBirth,@Gender)", conn);
                cmd.Parameters.Add(new SqlParameter("@NameEmp", emp.tenNV));
                cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Donvi.IdDepartment));
                cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.Noisinh));
                cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.ngaysinh));
                cmd.Parameters.Add(new SqlParameter("@Gender", emp.gioitinh));
                cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.Id));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
            public void EditEmployee(EmployeeDTO emp)
            {
                SqlConnection conn = CreateConnection();
                conn.Open();
                SqlCommand cmd = new SqlCommand(
                    "update Employee_2119110268 set NameEmp = @NameEmp, IdEmployee = @IdEmployee," +
                    "IdDepartment=@IdDepartment, PlaceBirth=@PlaceBirth," +
                    "DateBirth=@DateBirth, Gender=@Gender where @IdEmployee = IdEmployee", conn);
                cmd.Parameters.Add(new SqlParameter("@IdEmployee", emp.Id));
                cmd.Parameters.Add(new SqlParameter("@NameEmp", emp.tenNV));
                cmd.Parameters.Add(new SqlParameter("@IdDepartment", emp.Donvi.IdDepartment));
                cmd.Parameters.Add(new SqlParameter("@PlaceBirth", emp.Noisinh));
                cmd.Parameters.Add(new SqlParameter("@DateBirth", emp.ngaysinh));
                cmd.Parameters.Add(new SqlParameter("@Gender", emp.gioitinh));
                cmd.ExecuteNonQuery();
                conn.Close();
            }
        }
    }

