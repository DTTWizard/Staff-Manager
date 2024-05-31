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
    public partial class InLuongTheoPb : Form
    {
        public InLuongTheoPb()
        {
            InitializeComponent();
        }

        private void btnIn_Click(object sender, EventArgs e)
        {
            {
                string departmentName = tbTenPhongBan.Text.Trim();

                if (string.IsNullOrEmpty(departmentName))
                {
                    MessageBox.Show("Please enter a department name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                DataTable dt = GetSalaryData(departmentName);

                dgvLuong.DataSource = dt;
            }
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private DataTable GetSalaryData(string departmentName)
        {
            DataTable dt = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = @"
                    SELECT
                        P.TenPhongBan AS 'TenPhongBan',
                        CB.HoTen AS 'TenCanBo',
                        L.Luong AS 'Luong',
                        L.Thang AS 'Thang',
                        L.Nam AS 'Nam'
                    FROM
                        Luong L
                    INNER JOIN CanBo CB ON L.MaCanBo = CB.MaCanBo
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
        private void button1_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }
    }
}
