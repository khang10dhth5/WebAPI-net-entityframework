using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_net_entityframework.Data
{
    public class HangHoaData
    {
        public Guid MaHH { get; set; }
        public string TenHH { get; set; }
        public string MoTa { get; set; }
        public Double DonGia { get; set; }
        public int MaLoai { get; set; }
        public LoaiData Loai { get; set; }
        public ICollection<ChiTietDHData> DHChiTiets { get; set; }
        public HangHoaData()
        {
            DHChiTiets = new List<ChiTietDHData>();
        }
    }
}
