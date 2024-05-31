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
    public partial class TimkiemtheoId : Form
    {
        public TimkiemtheoId()
        {
            InitializeComponent();
        }
        private string connectionString = "Data Source=TRONGTIEN\\MAY1;Initial Catalog=BTLQUANLI;Integrated Security=True";
        private void SearchById(int maCanBo)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string selectCanBoSql = "SELECT * FROM CanBo WHERE MaCanBo = @MaCanBo";

                using (SqlCommand command = new SqlCommand(selectCanBoSql, connection))
                {
                    command.Parameters.AddWithValue("@MaCanBo", maCanBo);

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        System.Data.DataTable dataTable = new System.Data.DataTable();
                        adapter.Fill(dataTable);
                        dgvTimKiem.DataSource = dataTable;
                    }
                }
            }
        }
        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            try
            {

                int maCanBo;
                if (!int.TryParse(tbMaCanBo.Text, out maCanBo))
                {
                    MessageBox.Show("Vui lòng nhập một số nguyên làm ID cán bộ.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                SearchById(maCanBo);
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
