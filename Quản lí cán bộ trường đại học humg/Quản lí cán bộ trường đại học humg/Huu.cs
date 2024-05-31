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
    public partial class Huu : Form
    {
        public Huu()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";

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
                DateTime ngayVeHuu = dateTimePickerNgayVeHuu.Value;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    string selectCanBoSql = "SELECT * FROM CanBo WHERE YEAR(NgayVeHuu) = @NamVeHuu";

                    using (SqlCommand command = new SqlCommand(selectCanBoSql, connection))
                    {
                        command.Parameters.AddWithValue("@NamVeHuu", ngayVeHuu.Year);

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

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
            TrangChu trangChu = new TrangChu();
            trangChu.Show();
            this.Close();
        }
    }
}
