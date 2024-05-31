using Quản_lí_cán_bộ_trường_đại_học_mỏ_địa_chất_hà_nội;
using QuanLiCanBoTruongDaiHocHUMG;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public partial class TrangChu : Form
    {
        public TrangChu()
        {
            InitializeComponent();
        }

        private void giớiThiệuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            GioiThieu gioiThieu = new GioiThieu();
            gioiThieu.Show();
            this.Hide();
        }

     
        private void thêmPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemPb themPb = new ThemPb(); 
            themPb.Show();
            this.Hide();
        }

        private void sửaPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuaPb suaPb = new SuaPb();
            suaPb.Show();
            this.Hide();
        }

        private void xóaPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaPb xoaPb = new XoaPb();
            xoaPb.Show();
            this.Hide();
        }

        private void thêmCánBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemCb thmCb = new ThemCb();
            thmCb.Show();
            this.Hide();
        }

        private void sửaThôngTinCánBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SuattCb suattCb = new SuattCb();
            suattCb.Show();
            this.Hide();
        }

        private void xóaThôngTinCánBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            XoaCb xoaCb = new XoaCb();
            xoaCb.Show();
            this.Hide();
        }

        private void thêmLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThemLuong themLuongCb = new ThemLuong();
            themLuongCb.Show(); 
            this.Hide();
        }

        private void chỉnhLươngCánBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Chinhluong chinhluong  = new Chinhluong();
            chinhluong.Show();
            this.Hide();
        }

        private void xóaLươngCánBộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Xoaluong xoaLuong = new Xoaluong();
            xoaLuong.Show();
            this.Hide();
        }

        private void tìmCansBộTheoIdToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TimkiemtheoId timkiemtheoId = new TimkiemtheoId();
            timkiemtheoId.Show();
            this.Hide();
        }

        private void tìmCánBộTheoTrìnhĐộToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TheoTd theoTd = new TheoTd();
            theoTd.Show();
            this.Hide();
        }

        private void tìmCánBộTheoChứcVụToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ThongkeTheocv thongkeTheocv = new ThongkeTheocv();
            thongkeTheocv.Show();
            this.Hide();
        }

        private void danhSáchCủaMộtPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DanhsachCb danhsachCb = new DanhsachCb();
            danhsachCb.Show();
            this.Hide();
        }

        private void bảngLươngCủaMộtPhòngBanToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InLuongTheoPb inLuongTheoPb = new InLuongTheoPb();
            inLuongTheoPb.Show();
            this.Hide();
        }

     

        private void danhSáchCánBộVềHưuTrongNămToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Huu huu = new Huu(); 
            huu.Show();
            this.Hide();
        }

        private void càiĐặtToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void trợGiúpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            TroGiup troGiup = new TroGiup();
            troGiup.Show();
            this.Hide();
        }

        private void danhSáchNhữngCánBộĐượcTăngLươngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Luongtang luongtang = new Luongtang();
            luongtang.Show();
            this.Hide();
        }

        private void sắpXếpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SapXep sapXep = new SapXep();
            sapXep.Show();
            this.Hide();
        }
    }
}
