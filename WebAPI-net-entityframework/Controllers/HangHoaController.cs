using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebAPI_net_entityframework.Data;
using WebAPI_net_entityframework.Models;

namespace WebAPI_net_entityframework.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HangHoaController : ControllerBase
    {
        private readonly MyDBContext _context;
        public HangHoaController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsHH = _context.HangHoas.ToList();
            return Ok(dsHH);
        }
        [HttpGet("Id")]
        public IActionResult GetById(string id)
        {
            try
            {
                var HangHoa = _context.HangHoas.SingleOrDefault(ll => ll.MaHH == Guid.Parse(id));
                if (HangHoa == null)
                {
                    return NotFound();
                }
                return Ok(HangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpPost]
        public IActionResult CreateNew(HangHoaModel model,int maloai)
        {
            var HangHoa = new HangHoaData();
            HangHoa.TenHH = model.TenHH;
            HangHoa.MoTa = model.MoTa;
            HangHoa.DonGia = model.DonGia;
            HangHoa.MaLoai = maloai;
            _context.Add(HangHoa);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPut("id")]
        public IActionResult Update( HangHoaModel model, string id)
        {
            try
            {
                var HangHoa = _context.HangHoas.SingleOrDefault(l => l.MaHH == Guid.Parse(id));
                if (HangHoa == null)
                {
                    return NotFound();
                }
                HangHoa.TenHH = model.TenHH;
                HangHoa.MoTa = model.MoTa;
                HangHoa.DonGia = model.DonGia;
                _context.SaveChanges();
                return Ok(HangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
        [HttpDelete("id")]
        public IActionResult Delete(string id)
        {
            try
            {
                var HangHoa = _context.HangHoas.SingleOrDefault(l => l.MaHH == Guid.Parse(id));
                if (HangHoa == null)
                {
                    return NotFound();
                }
                _context.Remove(HangHoa);
                _context.SaveChanges();
                return Ok(HangHoa);
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}
