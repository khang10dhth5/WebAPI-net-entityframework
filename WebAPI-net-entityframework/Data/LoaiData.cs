using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI_net_entityframework.Data
{
    public class LoaiData
    {
        public int MaLoai { get; set; }
        public string TenLoai { get; set; }
        public ICollection<HangHoaData> HangHoas { get; set; }
        public LoaiData()
        {
            HangHoas = new HashSet<HangHoaData>();
        }
    }
}
