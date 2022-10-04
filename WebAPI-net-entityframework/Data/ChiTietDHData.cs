using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_net_entityframework.Data
{
    public class ChiTietDHData
    {
        public Guid MaDH { get; set; }
        public Guid MaHH { get; set; }
        public int soluong { get; set; }
        public double DonGia { get; set; }
        public double GiamGia { get; set; }
        public DonHangData DonHang { get; set; }
        public HangHoaData HangHoa { get; set; }
    }
}
