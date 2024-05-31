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
    public partial class TheoTd : Form
    {
        public TheoTd()
        {
            InitializeComponent();
            LoadTrinhDo();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private void LoadQualifications()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string query = "SELECT DISTINCT TrinhDo FROM CanBo";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                cbTrinhDo.Items.Add(reader["TrinhDo"].ToString());
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading qualifications: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnTimkiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input (e.g., check if a trinh do is selected)
                if (cbTrinhDo.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn một trình độ để thực hiện tìm kiếm.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Perform the search based on the selected trinh do
                string selectedTrinhDo = cbTrinhDo.SelectedItem.ToString();
                TimKiemTheoTrinhDo(selectedTrinhDo);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void TimKiemTheoTrinhDo(string trinhDo)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectCanBoSql = "SELECT * FROM CanBo WHERE TrinhDo = @TrinhDo";

                    using (SqlCommand command = new SqlCommand(selectCanBoSql, connection))
                    {
                        command.Parameters.AddWithValue("@TrinhDo", trinhDo);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Create a DataTable to hold the results
                            DataTable dataTable = new DataTable();

                            // Fill the DataTable with the results
                            adapter.Fill(dataTable);

                            // Display the results in the DataGridView
                            dgvCanBo.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadTrinhDo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectTrinhDoSql = "SELECT DISTINCT TrinhDo FROM CanBo";

                    using (SqlCommand command = new SqlCommand(selectTrinhDoSql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string trinhDo = reader["TrinhDo"].ToString();
                                cbTrinhDo.Items.Add(trinhDo);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
