using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public class CanBo
    {
        public int MaCanBo { get; set; }
        public string HoTen { get; set; }
        public int MaPhongBan { get; set; }
        public string TrinhDo { get; set; }
        public string ChucVu { get; set; }
        public DateTime NgayVeHuu { get; set; }
        public PhongBan PhongBan { get; set; }

        public override string ToString()
        {
            return HoTen;
        }

    }
}
