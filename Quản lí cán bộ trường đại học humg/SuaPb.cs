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
    public partial class SuaPb : Form
    {
        public SuaPb()
        {
            InitializeComponent();
            LoadPhongBan();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
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

                        PhongBan.DisplayMember = "TenPhongBan";
                        PhongBan.ValueMember = "MaPhongBan";
                        PhongBan.DataSource = reader.HasRows ? reader.Cast<IDataRecord>().Select(r => new { MaPhongBan = r.GetInt32(0), TenPhongBan = r.GetString(1) }).ToList() : null;
                    }
                }
            }
        }
        private void SuaPhongBan(int maPhongBan, string tenMoi)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string updatePhongBanSql = "UPDATE PhongBan SET TenPhongBan = @TenPhongBan WHERE MaPhongBan = @MaPhongBan";

                using (SqlCommand command = new SqlCommand(updatePhongBanSql, connection))
                {
                    command.Parameters.AddWithValue("@TenPhongBan", tenMoi);
                    command.Parameters.AddWithValue("@MaPhongBan", maPhongBan);

                    command.ExecuteNonQuery();
                }
            }
        }


        private void btnSua_Click(object sender, EventArgs e)
        {
            if (PhongBan.SelectedItem != null)
            {
                var selectedPhongBan = (dynamic)PhongBan.SelectedItem;
                int maPhongBan = selectedPhongBan.MaPhongBan;
                string tenMoi = tbTenMoi.Text;
                SuaPhongBan(maPhongBan, tenMoi);
                MessageBox.Show("Sửa thông tin phòng ban thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadPhongBan();

                PhongBan.Text = tenMoi;
                lbPbMoi.Items.Add($"{maPhongBan}: {tenMoi}");
            }
            else
            {
                MessageBox.Show("Vui lòng chọn phòng ban để sửa.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
