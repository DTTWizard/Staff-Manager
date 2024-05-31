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
    public partial class ThemPb : Form
    {
        public ThemPb()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        private void btnThem_Click(object sender, EventArgs e)
        {
            string tenPhongBan = tbThemPb.Text;

            if (!string.IsNullOrEmpty(tenPhongBan))
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();

                        // Thêm phòng ban vào cơ sở dữ liệu
                        string insertQuery = "INSERT INTO PhongBan (TenPhongBan) VALUES (@TenPhongBan)";
                        using (SqlCommand command = new SqlCommand(insertQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                            command.ExecuteNonQuery();
                        }

                        // Lấy mã phòng ban vừa thêm
                        string selectQuery = "SELECT MaPhongBan FROM PhongBan WHERE TenPhongBan = @TenPhongBan";
                        using (SqlCommand command = new SqlCommand(selectQuery, connection))
                        {
                            command.Parameters.AddWithValue("@TenPhongBan", tenPhongBan);
                            int maPhongBan = (int)command.ExecuteScalar();

                            listBoxPhongBan.Items.Add($"{maPhongBan}: {tenPhongBan}");
                        }
                    }

                    MessageBox.Show("Thêm phòng ban thành công!");
                    tbThemPb.Clear();
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi: {ex.Message}");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên phòng ban!");
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
