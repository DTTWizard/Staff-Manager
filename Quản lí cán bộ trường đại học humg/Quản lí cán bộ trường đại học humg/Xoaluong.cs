using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public partial class Xoaluong : Form
    {
        private string ConnectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        public Xoaluong()
        {
            InitializeComponent();
            LoadMaCanBoList();
        }

        private void LoadMaCanBoList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();
                    string query = "SELECT MaCanBo FROM CanBo";
                    SqlCommand command = new SqlCommand(query, connection);

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int maCanBo = reader.GetInt32(0);
                            cbMaCanBo.Items.Add(maCanBo);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading MaCanBo list: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnXoaLuong_Click(object sender, EventArgs e)
        {
            try
            {
                if (cbMaCanBo.SelectedItem == null)
                {
                    MessageBox.Show("Vui lòng chọn mã cán bộ.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                int maCanBoToDelete = (int)cbMaCanBo.SelectedItem;

                using (SqlConnection connection = new SqlConnection(ConnectionString))
                {
                    connection.Open();

                    // SQL query to delete records from Luong table
                    string deleteLuongQuery = "DELETE FROM Luong WHERE MaCanBo = @MaCanBoToDelete";

                    using (SqlCommand deleteLuongCommand = new SqlCommand(deleteLuongQuery, connection))
                    {
                        // Add parameter to the command
                        deleteLuongCommand.Parameters.AddWithValue("@MaCanBoToDelete", maCanBoToDelete);

                        // Execute the command
                        deleteLuongCommand.ExecuteNonQuery();

                        MessageBox.Show("Xóa lương thành công.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
