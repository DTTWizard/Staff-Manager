using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public partial class Luongtang : Form
    {
        private string ConnectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        public Luongtang()
        {
            InitializeComponent();
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    string query = @"
                        SELECT
                            CanBo.MaCanBo,
                            CanBo.HoTen,
                            Luong.Luong AS LuongHienTai,
                            YeuCauChinhLuong.LuongMoi AS LuongMoi,
                            YeuCauChinhLuong.ThangMoi,
                            YeuCauChinhLuong.NamMoi,
                            YeuCauChinhLuong.NgayYeuCau,
                            YeuCauChinhLuong.TrangThai
                        FROM
                            CanBo
                        JOIN
                            YeuCauChinhLuong ON CanBo.MaCanBo = YeuCauChinhLuong.MaCanBo
                        JOIN
                            Luong ON CanBo.MaCanBo = Luong.MaCanBo AND YeuCauChinhLuong.MaYeuCau = Luong.MaYeuCau
                        WHERE
                            YeuCauChinhLuong.TrangThai = 'đã duyệt' AND YeuCauChinhLuong.LuongMoi > Luong.Luong;
                    ";

                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvLuong.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
