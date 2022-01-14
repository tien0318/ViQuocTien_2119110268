using Cau1.BAL;
using Cau1.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cau1
{
    public partial class NhanVien : Form
    {
        EmployeeBAL empBAL = new EmployeeBAL() ;
        DepartmentiBAL depBAL = new DepartmentiBAL() ;

        public NhanVien()
        {
            InitializeComponent();
        }

        private void NhanVien_Load(object sender, EventArgs e)
        {
            List<EmployeeDTO> lstEmp = empBAL.ReadEmployee();
            foreach (EmployeeDTO emp in lstEmp)
            {
                dgvEmployee.Rows.Add(emp.Id, emp.tenNV, emp.Noisinh, emp.ngaysinh.Date.ToString(), emp.gioitinh, emp.DepartmenntName);
            }
         
            List<DepartmentDTO> lstDepartment = depBAL.ReadDepartmentList();
            foreach (DepartmentDTO dep in lstDepartment)
            {
                cbDepartment.Items.Add(dep);
            }
            cbDepartment.DisplayMember = "NameDep";

        }

        private void dgvEmployee_RowEnter(object sender, DataGridViewCellEventArgs e)
        {
            int idx = e.RowIndex;
            DataGridViewRow row = dgvEmployee.Rows[idx];
            if (row.Cells[0].Value != null)
            {
                tbIDEmp.Text = row.Cells[0].Value.ToString();
                tbName.Text = row.Cells[1].Value.ToString();
                tbPlaceBirth.Text = row.Cells[2].Value.ToString();
                dtDateBirth.Text = row.Cells[3].Value.ToString();
                int gioitinh = int.Parse(row.Cells[4].Value.ToString());
                if (gioitinh == 1)
                {
                    chbGender.Checked = true;
                }
                else
                {
                    chbGender.Checked = false;
                }
                cbDepartment.Text = row.Cells[5].Value.ToString();
            }
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            EmployeeDTO emp = new EmployeeDTO();

            if (tbIDEmp.Text.Equals("") || tbName.Text.Equals("") || tbPlaceBirth.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống!", "THÔNG BÁO");
            }
            else
            {
                emp.Id = tbIDEmp.Text;
                emp.tenNV = tbName.Text;
                emp.Noisinh = tbPlaceBirth.Text;
                emp.Donvi = (DepartmentDTO)cbDepartment.SelectedItem;
                emp.ngaysinh = dtDateBirth.Value;
                if (chbGender.Checked)
                {
                    emp.gioitinh = 1;
                }
                else
                {
                    emp.gioitinh = 0;
                }
                empBAL.NewEmployee(emp);
                dgvEmployee.Rows.Add(emp.Id, emp.tenNV, emp.Noisinh, emp.ngaysinh, emp.gioitinh, emp.DepartmenntName);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn xóa", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            //EmployeeDTO emp = new EmployeeDTO();
            //if (tbIDEmp.Text.Equals("") || tbName.Text.Equals("") || tbPlaceBirth.Equals(""))
            //{
            //    MessageBox.Show("Không đc bỏ trống!", "THÔNG BÁO");

            //}
            //else if (dlr == DialogResult.yes)
            //{
            //    emp.Id = tbIDEmp.Text;
            //    emp.tenNV = tbName.Text;
            //    emp.Noisinh = tbPlaceBirth.Text;
            //    emp.Donvi = (DepartmentDTO)cbDepartment.SelectedItem;
            //    emp.ngaysinh = dtDateBirth.Value;
            //    if (chbGender.Checked)
            //    {
            //        emp.gioitinh = 1;
            //    }
            //    else
            //    {
            //        emp.gioitinh = 0;
            //    }
            //    empBAL.DeleteEmployee(emp);
            //    int idx = dgvEmployee.CurrentCell.RowIndex;
            //    dgvEmployee.Rows.RemoveAt(idx);


            //}
            //else { };
            EmployeeDTO emp = new EmployeeDTO();
            emp.Id = tbIDEmp.Text;
            emp.tenNV = tbName.Text;

            empBAL.DeleteEmployee(emp);

            int idx = dgvEmployee.CurrentCell.RowIndex;
            dgvEmployee.Rows.RemoveAt(idx);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc muốn sửa", "thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            EmployeeDTO emp = new EmployeeDTO();

            if (tbIDEmp.Text.Equals("") || tbName.Text.Equals("") || tbPlaceBirth.Equals(""))
            {
                MessageBox.Show("Không được bỏ trống!", "THÔNG BÁO");
            }
            else
            {
                emp.Id = tbIDEmp.Text;
                emp.tenNV = tbName.Text;
                emp.Noisinh = tbPlaceBirth.Text;
                emp.Donvi = (DepartmentDTO)cbDepartment.SelectedItem;
                emp.ngaysinh = dtDateBirth.Value;
                if (chbGender.Checked)
                {
                    emp.gioitinh = 1;
                }
                else
                {
                    emp.gioitinh = 0;
                }
                empBAL.EditEmployee(emp);
                using DataGridViewRow row = dgvEmployee.CurrentRow;
                row.Cells[0].Value = emp.Id;
                row.Cells[1].Value = emp.tenNV;
                row.Cells[2].Value = emp.Noisinh;
                row.Cells[3].Value = emp.ngaysinh;
                row.Cells[4].Value = emp.gioitinh;
                row.Cells[5].Value = emp.DepartmenntName;
            }

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
              "Bạn có chắc muốn thoát không",

              "Thông báo",
              MessageBoxButtons.YesNo,
              MessageBoxIcon.Question
            );
            if (result == DialogResult.Yes)
            {
                Application.Exit();

            }
        }

    }
}
