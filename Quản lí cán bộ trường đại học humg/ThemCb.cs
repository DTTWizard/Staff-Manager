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
    public partial class ThemCb : Form
    {
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        public ThemCb()
        {
            InitializeComponent();
            LoadPhongBan();
            LoadDataGrid();
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
                        if (reader.HasRows)
                        {
                            var phongBanList = reader.Cast<IDataRecord>()
                                .Select(r => new PhongBan
                                {
                                    MaPhongBan = r.GetInt32(0),
                                    TenPhongBan = r.GetString(1)
                                }).ToList();

                            cbMaPhongBan.DisplayMember = "TenPhongBan";
                            cbMaPhongBan.ValueMember = "MaPhongBan";
                            cbMaPhongBan.DataSource = phongBanList;
                        }
                    }
                }
            }
        }

        private void LoadDataGrid()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = @"SELECT CanBo.MaCanBo, CanBo.HoTen, PhongBan.TenPhongBan, CanBo.TrinhDo, CanBo.ChucVu, CanBo.NgayVeHuu
                                    FROM CanBo
                                    JOIN PhongBan ON CanBo.MaPhongBan = PhongBan.MaPhongBan";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        dgvThemCb.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool IsExists(string tableName, string columnName, int value)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkExistsSql = $"SELECT COUNT(*) FROM {tableName} WHERE {columnName} = @Value";

                using (SqlCommand command = new SqlCommand(checkExistsSql, connection))
                {
                    command.Parameters.AddWithValue("@Value", value);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count > 0;
                }
            }
        }

        private void InsertCanBo(int maCanBo, string hoTen, int maPhongBan, string trinhDo, string chucVu, DateTime ngayVeHuu)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string insertCanBoSql = "INSERT INTO CanBo (MaCanBo, HoTen, MaPhongBan, TrinhDo, ChucVu, NgayVeHuu) " +
                                        "VALUES (@MaCanBo, @HoTen, @MaPhongBan, @TrinhDo, @ChucVu, @NgayVeHuu)";

                using (SqlCommand command = new SqlCommand(insertCanBoSql, connection))
                {
                    command.Parameters.AddWithValue("@MaCanBo", maCanBo);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                    command.Parameters.AddWithValue("@TrinhDo", trinhDo);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@NgayVeHuu", ngayVeHuu);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnThemCb_Click(object sender, EventArgs e)
        {
            try
            {
                int maCanBo = Convert.ToInt32(tbMaCanBo.Text); // Provide the desired MaCanBo value
                string hoTen = tbHoTen.Text;
                int maPhongBan = Convert.ToInt32(cbMaPhongBan.SelectedValue);
                string trinhDo = tbTrinhDo.Text;
                string chucVu = tbChucVu.Text;
                DateTime ngayVeHuu = dtpNgayVeHuu.Value;

                if (!IsExists("PhongBan", "MaPhongBan", maPhongBan))
                {
                    MessageBox.Show("MaPhongBan does not exist in PhongBan table.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                InsertCanBo(maCanBo, hoTen, maPhongBan, trinhDo, chucVu, ngayVeHuu);
                MessageBox.Show("Thêm cán bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSuaCb_Click(object sender, EventArgs e)
        {
            try
            {
                int maCanBo = Convert.ToInt32(tbMaCanBo.Text);
                string hoTen = tbHoTen.Text;
                int maPhongBan = Convert.ToInt32(cbMaPhongBan.SelectedValue);
                string trinhDo = tbTrinhDo.Text;
                string chucVu = tbChucVu.Text;
                DateTime ngayVeHuu = dtpNgayVeHuu.Value;

                UpdateCanBo(maCanBo, hoTen, maPhongBan, trinhDo, chucVu, ngayVeHuu);
                MessageBox.Show("Cập nhật cán bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateCanBo(int maCanBo, string hoTen, int maPhongBan, string trinhDo, string chucVu, DateTime ngayVeHuu)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string updateCanBoSql = "UPDATE CanBo SET HoTen = @HoTen, MaPhongBan = @MaPhongBan, TrinhDo = @TrinhDo, ChucVu = @ChucVu, NgayVeHuu = @NgayVeHuu " +
                                        "WHERE MaCanBo = @MaCanBo";

                using (SqlCommand command = new SqlCommand(updateCanBoSql, connection))
                {
                    command.Parameters.AddWithValue("@MaCanBo", maCanBo);
                    command.Parameters.AddWithValue("@HoTen", hoTen);
                    command.Parameters.AddWithValue("@MaPhongBan", maPhongBan);
                    command.Parameters.AddWithValue("@TrinhDo", trinhDo);
                    command.Parameters.AddWithValue("@ChucVu", chucVu);
                    command.Parameters.AddWithValue("@NgayVeHuu", ngayVeHuu);

                    command.ExecuteNonQuery();
                }
            }
        }

        private void btnThoatCb_Click_1(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Hide();
        }
    }
}
