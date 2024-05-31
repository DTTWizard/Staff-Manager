using Quản_lí_cán_bộ_trường_đại_học_humg;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLiCanBoTruongDaiHocHUMG
{
    public partial class Chinhluong : Form
    {
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private SqlConnection mainConnection; 

        public Chinhluong()
        {
            InitializeComponent();
            LoadMaCanBoToComboBox();
        }

        private void LoadMaCanBoToComboBox()
        {
            try
            {
                using (mainConnection = new SqlConnection(connectionString))
                {
                    mainConnection.Open();

                    string query = "SELECT MaCanBo FROM CanBo";

                    using (SqlCommand command = new SqlCommand(query, mainConnection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            // Bind the list of MaCanBo to the ComboBox
                            cbCanBo.DataSource = dt;
                            cbCanBo.DisplayMember = "MaCanBo";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

       

        

        private void btnChinhLuong_Click_1(object sender, EventArgs e)
        {
            string maCanBo = cbCanBo.Text;
            float luongMoi = float.Parse(tbLuongMoi.Text);
            int thangMoi = int.Parse(tbThangMoi.Text);
            int namMoi = int.Parse(tbNamMoi.Text);

            try
            {
                using (mainConnection = new SqlConnection(connectionString))
                {
                    mainConnection.Open();

                    string query = "UPDATE YeuCauChinhLuong SET LuongMoi = @LuongMoi, ThangMoi = @ThangMoi, NamMoi = @NamMoi, NgayYeuCau = GETDATE(), TrangThai = 'Đã xử lí' WHERE MaCanBo = @MaCanBo";

                    using (SqlCommand command = new SqlCommand(query, mainConnection))
                    {
                        command.Parameters.AddWithValue("@MaCanBo", maCanBo);
                        command.Parameters.AddWithValue("@LuongMoi", luongMoi);
                        command.Parameters.AddWithValue("@ThangMoi", thangMoi);
                        command.Parameters.AddWithValue("@NamMoi", namMoi);

                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Cập nhật lương thành công!Chúc thầy năm mới cũng được tăng lương:))");
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy cán bộ có mã tương ứng.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
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
