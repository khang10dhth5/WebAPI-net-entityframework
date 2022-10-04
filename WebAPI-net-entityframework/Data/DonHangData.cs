using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_net_entityframework.Data
{
    public class DonHangData
    {
        public Guid MaDH { get; set; }
        public DateTime NgayDat { get; set; }
        public DateTime NgayGiao { get; set; }
        public string NguoiNhan { get; set; }
        public string DiaChiGiaoP { get; set; }
        public string SDT { get; set; }
        public ICollection<ChiTietDHData> DHChiTiets { get; set; }
        public DonHangData()
        {
            DHChiTiets = new HashSet<ChiTietDHData>();
        }
    }
}
