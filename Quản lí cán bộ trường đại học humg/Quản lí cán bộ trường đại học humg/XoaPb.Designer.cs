namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    partial class XoaPb
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
            this.btnThoat = new System.Windows.Forms.Button();
            this.cbPhongBan = new System.Windows.Forms.ComboBox();
            this.ListXoaPb = new System.Windows.Forms.ListView();
            this.btnXoaPhongBan = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnThoat
            // 
            this.btnThoat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThoat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThoat.Location = new System.Drawing.Point(329, 300);
            this.btnThoat.Name = "btnThoat";
            this.btnThoat.Size = new System.Drawing.Size(86, 40);
            this.btnThoat.TabIndex = 25;
            this.btnThoat.Text = "Thoát";
            this.btnThoat.UseVisualStyleBackColor = true;
            this.btnThoat.Click += new System.EventHandler(this.btnThoat_Click);
            // 
            // cbPhongBan
            // 
            this.cbPhongBan.FormattingEnabled = true;
            this.cbPhongBan.Location = new System.Drawing.Point(148, 26);
            this.cbPhongBan.Name = "cbPhongBan";
            this.cbPhongBan.Size = new System.Drawing.Size(249, 21);
            this.cbPhongBan.TabIndex = 24;
            // 
            // ListXoaPb
            // 
            this.ListXoaPb.HideSelection = false;
            this.ListXoaPb.Location = new System.Drawing.Point(16, 140);
            this.ListXoaPb.Name = "ListXoaPb";
            this.ListXoaPb.Size = new System.Drawing.Size(399, 128);
            this.ListXoaPb.TabIndex = 23;
            this.ListXoaPb.UseCompatibleStateImageBehavior = false;
            // 
            // btnXoaPhongBan
            // 
            this.btnXoaPhongBan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaPhongBan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaPhongBan.Location = new System.Drawing.Point(191, 300);
            this.btnXoaPhongBan.Name = "btnXoaPhongBan";
            this.btnXoaPhongBan.Size = new System.Drawing.Size(86, 40);
            this.btnXoaPhongBan.TabIndex = 21;
            this.btnXoaPhongBan.Text = "Xóa";
            this.btnXoaPhongBan.UseVisualStyleBackColor = true;
            this.btnXoaPhongBan.Click += new System.EventHandler(this.btnXoaPhongBan_Click);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(27, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(370, 40);
            this.button1.TabIndex = 22;
            this.button1.Text = "Danh sách phòng ban mới xóa";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 26);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(124, 24);
            this.label1.TabIndex = 20;
            this.label1.Text = "Phòng ban :";
            // 
            // XoaPb
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightGray;
            this.ClientSize = new System.Drawing.Size(433, 368);
            this.Controls.Add(this.btnThoat);
            this.Controls.Add(this.cbPhongBan);
            this.Controls.Add(this.ListXoaPb);
            this.Controls.Add(this.btnXoaPhongBan);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Name = "XoaPb";
            this.ShowIcon = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            this.Text = "XÓA PHÒNG BAN";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnThoat;
        private System.Windows.Forms.ComboBox cbPhongBan;
        private System.Windows.Forms.ListView ListXoaPb;
        private System.Windows.Forms.Button btnXoaPhongBan;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
    }
}