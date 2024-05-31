using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public partial class SapXep : Form
    {
        public SapXep()
        {
            InitializeComponent();
            LoadPhongBan();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private void btnSapXep_Click(object sender, EventArgs e)
        {
            string selectedDepartment = cbPhongBan.SelectedItem?.ToString();

            if (string.IsNullOrEmpty(selectedDepartment))
            {
                MessageBox.Show("Please select a department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = GetDanhSachCanBo(selectedDepartment);
            DataView dv = dt.DefaultView;

            // Sort by 'EmployeeName' column in ascending order
            dv.Sort = "EmployeeName ASC";

            dataGridView1.DataSource = dv.ToTable();
        }
        private DataTable GetDanhSachCanBo(string departmentName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT
                        CB.HoTen AS 'TenCanBo',
                        CB.TrinhDo AS 'TrinhDo',
                        CB.ChucVu AS 'ChucVu'
                    FROM
                        CanBo CB
                    INNER JOIN PhongBan P ON CB.MaPhongBan = P.MaPhongBan
                    WHERE
                        P.TenPhongBan = @DepartmentName;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@DepartmentName", departmentName);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void LoadPhongBan()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "SELECT DISTINCT TenPhongBan FROM PhongBan;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            cbPhongBan.Items.Add(reader["TenPhongBan"].ToString());
                        }
                    }
                }
            }
        }



        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }
    }
}
