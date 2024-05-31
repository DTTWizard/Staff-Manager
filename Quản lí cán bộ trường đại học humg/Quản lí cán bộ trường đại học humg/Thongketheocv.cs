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
    public partial class ThongkeTheocv : Form
    {
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

        public ThongkeTheocv()
        {
            InitializeComponent();
            LoadChucVu();
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {
                // Validate user input (e.g., check if a job position is selected)
                if (cbChucVu.SelectedIndex == -1)
                {
                    MessageBox.Show("Vui lòng chọn một chức vụ để thống kê.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Perform the search based on the selected job position
                string selectedChucVu = cbChucVu.SelectedItem.ToString();
                ThongKeTheoChucVu(selectedChucVu);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThongKeTheoChucVu(string chucVu)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectCanBoSql = "SELECT * FROM CanBo WHERE ChucVu = @ChucVu";

                    using (SqlCommand command = new SqlCommand(selectCanBoSql, connection))
                    {
                        command.Parameters.AddWithValue("@ChucVu", chucVu);

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            // Create a DataTable to hold the results
                            DataTable dataTable = new DataTable();

                            // Fill the DataTable with the results
                            adapter.Fill(dataTable);

                            // Display the results in the DataGridView
                            dgvThongKe.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ThongkeTheocv_Load(object sender, EventArgs e)
        {
            LoadChucVu();
        }

        private void LoadChucVu()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectChucVuSql = "SELECT DISTINCT ChucVu FROM CanBo";

                    using (SqlCommand command = new SqlCommand(selectChucVuSql, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string chucVu = reader["ChucVu"].ToString();
                                cbChucVu.Items.Add(chucVu);
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
