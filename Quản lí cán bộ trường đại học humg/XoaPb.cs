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
    public partial class XoaPb : Form
    {
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog= BTLQUANLI;Integrated Security=True";

        public XoaPb()
        {
            InitializeComponent();
            LoadPhongBan();
        }

        private void LoadPhongBan()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string selectPhongBanSql = "SELECT * FROM PhongBan";

                using (SqlCommand command = new SqlCommand(selectPhongBanSql, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        cbPhongBan.DisplayMember = "TenPhongBan";
                        cbPhongBan.ValueMember = "MaPhongBan";
                        cbPhongBan.DataSource = reader.HasRows
                            ? reader.Cast<IDataRecord>().Select(r => new { MaPhongBan = r.GetInt32(0), TenPhongBan = r.GetString(1) }).ToList()
                            : null;
                    }
                }
            }
        }

        private void XoaPhongBan(int maPhongBan)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkPhongBanSql = "SELECT COUNT(*) FROM PhongBan WHERE MaPhongBan = @MaPhongBan";

                using (SqlCommand checkCommand = new SqlCommand(checkPhongBanSql, connection))
                {
                    checkCommand.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                    int departmentCount = (int)checkCommand.ExecuteScalar();

                    if (departmentCount == 0)
                    {
                        MessageBox.Show("Phòng ban không tồn tại trong cơ sở dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                string checkEmployeesSql = "SELECT COUNT(*) FROM CanBo WHERE MaPhongBan = @MaPhongBan";

                using (SqlCommand checkEmployeesCommand = new SqlCommand(checkEmployeesSql, connection))
                {
                    checkEmployeesCommand.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                    int employeeCount = (int)checkEmployeesCommand.ExecuteScalar();

                    if (employeeCount > 0)
                    {
                        MessageBox.Show("Phòng ban này có cán bộ. Vui lòng chọn phòng ban khác để chuyển cán bộ trước khi xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
                string deletePhongBanSql = "DELETE FROM PhongBan WHERE MaPhongBan = @MaPhongBan";

                using (SqlCommand deleteCommand = new SqlCommand(deletePhongBanSql, connection))
                {
                    deleteCommand.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                    int rowsAffected = deleteCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadPhongBan();

                        ListXoaPb.Items.Add($"{maPhongBan}: {cbPhongBan.Text}");
                    }
                    else
                    {
                        MessageBox.Show("Xóa phòng ban không thành công!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoaPhongBan_Click(object sender, EventArgs e)
        {
            if (cbPhongBan.SelectedItem != null)
            {
                var selectedPhongBan = (dynamic)cbPhongBan.SelectedItem;
                int maPhongBan = selectedPhongBan.MaPhongBan;

                // Xóa phòng ban
                XoaPhongBan(maPhongBan);
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban để xóa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();

        }
    }
}
