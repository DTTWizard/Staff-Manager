using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public partial class XoaCb : Form
    {
        private readonly string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private DataTable deletedStaffDataTable;

        public XoaCb()
        {
            InitializeComponent();
            InitializeDeletedStaffDataTable();
            LoadTenPhongBan();
        }

        private void InitializeDeletedStaffDataTable()
        {
            deletedStaffDataTable = new DataTable();
            deletedStaffDataTable.Columns.Add("MaCanBo", typeof(int));
            deletedStaffDataTable.Columns.Add("HoTen", typeof(string));
            deletedStaffDataTable.Columns.Add("TenPhongBan", typeof(string));
            deletedStaffDataTable.Columns.Add("TrinhDo", typeof(string));
            deletedStaffDataTable.Columns.Add("ChucVu", typeof(string));
            deletedStaffDataTable.Columns.Add("NgayVeHuu", typeof(DateTime));

            dgvXoaCb.DataSource = deletedStaffDataTable;
        }

        private void LoadTenPhongBan()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectTenPhongBanSql = "SELECT DISTINCT TenPhongBan FROM CanBo JOIN PhongBan ON CanBo.MaPhongBan = PhongBan.MaPhongBan";

                    using (SqlCommand command = new SqlCommand(selectTenPhongBanSql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbTenPhongBan.Items.Add(reader.GetString(0));
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

        private bool CanDeleteCanBo(int maCanBo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string checkLuongExistsSql = "SELECT COUNT(*) FROM Luong WHERE MaCanBo = @MaCanBo";

                using (SqlCommand command = new SqlCommand(checkLuongExistsSql, connection))
                {
                    command.Parameters.AddWithValue("@MaCanBo", maCanBo);

                    int count = Convert.ToInt32(command.ExecuteScalar());

                    return count == 0;
                }
            }
        }

        private void DeleteCanBo(int maCanBo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCanBoInfoSql = "SELECT * FROM CanBo WHERE MaCanBo = @MaCanBo";

                using (SqlCommand selectCommand = new SqlCommand(selectCanBoInfoSql, connection))
                {
                    selectCommand.Parameters.AddWithValue("@MaCanBo", maCanBo);

                    using (SqlDataReader reader = selectCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            DataRow newRow = deletedStaffDataTable.NewRow();
                            newRow["MaCanBo"] = Convert.ToInt32(reader["MaCanBo"]);
                            newRow["HoTen"] = reader["HoTen"].ToString();
                            newRow["TenPhongBan"] = reader["MaPhongBan"].ToString(); // Fix: Replace with the correct column name
                            newRow["TrinhDo"] = reader["TrinhDo"].ToString();
                            newRow["ChucVu"] = reader["ChucVu"].ToString();
                            newRow["NgayVeHuu"] = Convert.ToDateTime(reader["NgayVeHuu"]);
                            deletedStaffDataTable.Rows.Add(newRow);

                            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa cán bộ này không?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                            if (result == DialogResult.Yes)
                            {
                                PerformDelete(maCanBo);
                            }
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy thông tin cán bộ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void PerformDelete(int maCanBo)
        {
            string deleteCanBoSql = "DELETE FROM CanBo WHERE MaCanBo = @MaCanBo";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                using (SqlCommand command = new SqlCommand(deleteCanBoSql, connection))
                {
                    command.Parameters.AddWithValue("@MaCanBo", maCanBo);

                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Xóa cán bộ thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa cán bộ. Có lỗi xảy ra.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnXoaCb_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(tbTenCanBo.Text))
                {
                    MessageBox.Show("Vui lòng nhập Tên Cán Bộ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                string tenCanBo = tbTenCanBo.Text;

                int maCanBo = GetMaCanBo(tenCanBo);

                if (maCanBo != -1)
                {
                    if (CanDeleteCanBo(maCanBo))
                    {
                        DeleteCanBo(maCanBo);
                    }
                    else
                    {
                        MessageBox.Show("Không thể xóa cán bộ. Có lương liên quan.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("Không tìm thấy cán bộ với Tên đã nhập.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private int GetMaCanBo(string tenCanBo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectMaCanBoSql = "SELECT MaCanBo FROM CanBo WHERE HoTen = @TenCanBo";

                    using (SqlCommand command = new SqlCommand(selectMaCanBoSql, connection))
                    {
                        command.Parameters.AddWithValue("@TenCanBo", tenCanBo);

                        object result = command.ExecuteScalar();

                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return -1;
            }
        }

        private void btnthoat_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }
    }
}
