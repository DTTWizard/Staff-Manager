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
    public partial class ThemLuong : Form
    {
        public ThemLuong()
        {
            InitializeComponent();
            LoadSalaryData();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private void btnNhap_Click(object sender, EventArgs e)
        {
            try
            {
                int maCanBo = Convert.ToInt32(cbMaCb.SelectedValue);
                float luong = float.Parse(tbLuong.Text);
                int thang = int.Parse(tbThang.Text);
                int nam = int.Parse(tbNam.Text);

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string insertQuery = "INSERT INTO Luong (MaCanBo, Luong, Thang, Nam) VALUES (@MaCanBo, @Luong, @Thang, @Nam)";

                    using (SqlCommand command = new SqlCommand(insertQuery, connection))
                    {
                        command.Parameters.AddWithValue("@MaCanBo", maCanBo);
                        command.Parameters.AddWithValue("@Luong", luong);
                        command.Parameters.AddWithValue("@Thang", thang);
                        command.Parameters.AddWithValue("@Nam", nam);

                        command.ExecuteNonQuery();

                        MessageBox.Show("Salary data inserted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);


                        LoadSalaryData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void LoadSalaryData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string selectEmployeeQuery = "SELECT MaCanBo FROM CanBo";

                    using (SqlCommand employeeCommand = new SqlCommand(selectEmployeeQuery, connection))
                    {
                        using (SqlDataAdapter employeeAdapter = new SqlDataAdapter(employeeCommand))
                        {
                            DataTable employeeDataTable = new DataTable();
                            employeeAdapter.Fill(employeeDataTable);
                            cbMaCb.DataSource = employeeDataTable;
                            cbMaCb.DisplayMember = "MaCanBo";
                            cbMaCb.ValueMember = "MaCanBo";
                        }
                    }
                    string selectSalaryQuery = "SELECT * FROM Luong";

                    using (SqlCommand command = new SqlCommand(selectSalaryQuery, connection))
                    {
                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable salaryDataTable = new DataTable();
                            adapter.Fill(salaryDataTable);
                            dgvLuong.DataSource = salaryDataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
