namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    partial class ThemCb
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvThemCb = new System.Windows.Forms.DataGridView();
            this.cbMaPhongBan = new System.Windows.Forms.ComboBox();
            this.btnThemCb = new System.Windows.Forms.Button();
            this.btnThoatCb = new System.Windows.Forms.Button();
            this.dtpNgayVeHuu = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbThemTd = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label = new System.Windows.Forms.Label();
            this.tbChucVu = new System.Windows.Forms.TextBox();
            this.tbTrinhDo = new System.Windows.Forms.TextBox();
            this.tbHoTen = new System.Windows.Forms.TextBox();
            this.tbMaCanBo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemCb)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvThemCb
            // 
            this.dgvThemCb.BackgroundColor = System.Drawing.SystemColors.ButtonHighlight;
            this.dgvThemCb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvThemCb.Location = new System.Drawing.Point(25, 163);
            this.dgvThemCb.Name = "dgvThemCb";
            this.dgvThemCb.Size = new System.Drawing.Size(605, 90);
            this.dgvThemCb.TabIndex = 34;
            // 
            // cbMaPhongBan
            // 
            this.cbMaPhongBan.FormattingEnabled = true;
            this.cbMaPhongBan.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5",
            "6",
            "7",
            "8",
            "9"});
            this.cbMaPhongBan.Location = new System.Drawing.Point(446, 20);
            this.cbMaPhongBan.Name = "cbMaPhongBan";
            this.cbMaPhongBan.Size = new System.Drawing.Size(186, 21);
            this.cbMaPhongBan.TabIndex = 33;
            // 
            // btnThemCb
            // 
            this.btnThemCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemCb.Location = new System.Drawing.Point(405, 281);
            this.btnThemCb.Name = "btnThemCb";
            this.btnThemCb.Size = new System.Drawing.Size(89, 27);
            this.btnThemCb.TabIndex = 31;
            this.btnThemCb.Text = "Thêm";
            this.btnThemCb.UseVisualStyleBackColor = true;
            this.btnThemCb.Click += new System.EventHandler(this.btnThemCb_Click);
            // 
            // btnThoatCb
            // 
            this.btnThoatCb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoatCb.Location = new System.Drawing.Point(540, 281);
            this.btnThoatCb.Name = "btnThoatCb";
            this.btnThoatCb.Size = new System.Drawing.Size(78, 27);
            this.btnThoatCb.TabIndex = 32;
            this.btnThoatCb.Text = "Thoát";
            this.btnThoatCb.UseVisualStyleBackColor = true;
            this.btnThoatCb.Click += new System.EventHandler(this.btnThoatCb_Click_1);
            // 
            // dtpNgayVeHuu
            // 
            this.dtpNgayVeHuu.Location = new System.Drawing.Point(118, 48);
            this.dtpNgayVeHuu.Name = "dtpNgayVeHuu";
            this.dtpNgayVeHuu.Size = new System.Drawing.Size(207, 20);
            this.dtpNgayVeHuu.TabIndex = 30;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(11, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 24;
            this.label3.Text = "Chức vụ :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(11, 52);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(97, 16);
            this.label1.TabIndex = 25;
            this.label1.Text = "Ngày về hưu:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(331, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 16);
            this.label2.TabIndex = 26;
            this.label2.Text = "Tên phòng ban :";
            // 
            // lbThemTd
            // 
            this.lbThemTd.AutoSize = true;
            this.lbThemTd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThemTd.Location = new System.Drawing.Point(331, 52);
            this.lbThemTd.Name = "lbThemTd";
            this.lbThemTd.Size = new System.Drawing.Size(72, 16);
            this.lbThemTd.TabIndex = 27;
            this.lbThemTd.Text = "Trình độ :";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(12, 20);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 28;
            this.label6.Text = "Họ tên    :";
            // 
            // label
            // 
            this.label.AutoSize = true;
            this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label.Location = new System.Drawing.Point(203, 126);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(243, 20);
            this.label.TabIndex = 29;
            this.label.Text = "Danh sách cán bộ được thêm";
            // 
            // tbChucVu
            // 
            this.tbChucVu.Location = new System.Drawing.Point(118, 90);
            this.tbChucVu.Multiline = true;
            this.tbChucVu.Name = "tbChucVu";
            this.tbChucVu.Size = new System.Drawing.Size(207, 20);
            this.tbChucVu.TabIndex = 21;
            // 
            // tbTrinhDo
            // 
            this.tbTrinhDo.Location = new System.Drawing.Point(444, 52);
            this.tbTrinhDo.Multiline = true;
            this.tbTrinhDo.Name = "tbTrinhDo";
            this.tbTrinhDo.Size = new System.Drawing.Size(186, 20);
            this.tbTrinhDo.TabIndex = 22;
            // 
            // tbHoTen
            // 
            this.tbHoTen.Location = new System.Drawing.Point(118, 18);
            this.tbHoTen.Multiline = true;
            this.tbHoTen.Name = "tbHoTen";
            this.tbHoTen.Size = new System.Drawing.Size(207, 20);
            this.tbHoTen.TabIndex = 23;
            // 
            // tbMaCanBo
            // 
            this.tbMaCanBo.Location = new System.Drawing.Point(446, 90);
            this.tbMaCanBo.Multiline = true;
            this.tbMaCanBo.Name = "tbMaCanBo";
            this.tbMaCanBo.Size = new System.Drawing.Size(186, 20);
            this.tbMaCanBo.TabIndex = 22;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(333, 90);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "MACB :";
            // 
            // ThemCb
            // 
            this.AcceptButton = this.btnThemCb;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(644, 315);
            this.Controls.Add(this.dgvThemCb);
            this.Controls.Add(this.cbMaPhongBan);
            this.Controls.Add(this.btnThemCb);
            this.Controls.Add(this.btnThoatCb);
            this.Controls.Add(this.dtpNgayVeHuu);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lbThemTd);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label);
            this.Controls.Add(this.tbChucVu);
            this.Controls.Add(this.tbMaCanBo);
            this.Controls.Add(this.tbTrinhDo);
            this.Controls.Add(this.tbHoTen);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "ThemCb";
            this.ShowIcon = false;
            this.Text = "THÊM CÁN BÔ";
            ((System.ComponentModel.ISupportInitialize)(this.dgvThemCb)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvThemCb;
        private System.Windows.Forms.ComboBox cbMaPhongBan;
        private System.Windows.Forms.Button btnThemCb;
        private System.Windows.Forms.Button btnThoatCb;
        private System.Windows.Forms.DateTimePicker dtpNgayVeHuu;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbThemTd;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.TextBox tbChucVu;
        private System.Windows.Forms.TextBox tbTrinhDo;
        private System.Windows.Forms.TextBox tbHoTen;
        private System.Windows.Forms.TextBox tbMaCanBo;
        private System.Windows.Forms.Label label4;
    }
}