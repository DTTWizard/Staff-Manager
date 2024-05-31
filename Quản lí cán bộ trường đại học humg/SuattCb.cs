using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public partial class SuattCb : Form
    {
        private readonly string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        public SuattCb()
        {
            InitializeComponent();
            LoadMaCanBo();
        }

        private void LoadMaCanBo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectMaCanBoSql = "SELECT MaCanBo FROM CanBo";

                    using (SqlCommand command = new SqlCommand(selectMaCanBoSql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbMACb.Items.Add(reader.GetInt32(0));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void btnThayDoi_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMACb.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn Mã Cán Bộ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maCanBo = Convert.ToInt32(cbMACb.SelectedItem);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string updateCanBoSql = @"UPDATE CanBo
                                              SET HoTen = @HoTen, MaPhongBan = @MaPhongBan, NgayVeHuu = @NgayVeHuu,
                                                  ChucVu = @ChucVu, TrinhDo = @TrinhDo
                                              WHERE MaCanBo = @MaCanBo";

                    using (SqlCommand command = new SqlCommand(updateCanBoSql, connection))
                    {
                        command.Parameters.AddWithValue("@MaCanBo", maCanBo);
                        command.Parameters.AddWithValue("@HoTen", tbHoTenMoi.Text);
                        command.Parameters.AddWithValue("@MaPhongBan", cbMaPhongBanMoi.SelectedItem);
                        command.Parameters.AddWithValue("@NgayVeHuu", dtpNgayVeHuuMoi.Value);
                        command.Parameters.AddWithValue("@ChucVu", tbChucVuMoi.Text);
                        command.Parameters.AddWithValue("@TrinhDo", tbTrinhDoMoi.Text);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Thay đổi thông tin cán bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Có lỗi xảy ra. Vui lòng thử lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (FormatException)
            {
                MessageBox.Show("Vui lòng nhập đúng định dạng dữ liệu.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu  trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
                
            
        }
    }
}
