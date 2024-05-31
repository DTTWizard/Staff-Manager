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
    public partial class DanhsachCb : Form
    {
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        public DanhsachCb()
        {
            InitializeComponent();

        }



        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            string phongBan = tbPhongBan.Text.Trim();

            if (string.IsNullOrEmpty(phongBan))
            {
                MessageBox.Show("Please enter a department name.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            DataTable dt = GetDanhSachCanBo(phongBan);
            dgvDanhSach.DataSource = dt;
        }

        private DataTable GetDanhSachCanBo(string phongBan)
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
                        P.TenPhongBan = @PhongBan;";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                {
                    cmd.Parameters.AddWithValue("@PhongBan", phongBan);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                    {
                        adapter.Fill(dt);
                    }
                }
            }

            return dt;
        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }
    }
}
