using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Quản_lí_cán_bộ_trường_đại_học_humg
{
    public class Luong
    {
        public int MaLuong { get; set; }
        public int MaCanBo { get; set; }
        public float LuongValue { get; set; }
        public int Thang { get; set; }
        public int Nam { get; set; }


        public CanBo CanBo { get; set; }
    }
}
