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
    public class LoaiController : ControllerBase
    {
        private readonly MyDBContext _context;
        public LoaiController(MyDBContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var dsLoai = _context.Loais.ToList();
            return Ok(dsLoai);
        }
        [HttpGet("Id")]
        public IActionResult GetById(int id)
        {
            var Loai = _context.Loais.SingleOrDefault(ll => ll.MaLoai == id);
            if (Loai == null)
            {
                return NotFound();
            }
            return Ok(Loai);
        }
        [HttpPost]
        public IActionResult CreateNew(LoaiModel model)
        {
            var loai = new LoaiData();
            loai.TenLoai = model.TenLoai;
            _context.Add(loai);
            _context.SaveChanges();
            return Ok();

        }
        [HttpPut("id")]
        public IActionResult Update(int id, LoaiModel model)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }
            loai.TenLoai = model.TenLoai;
            _context.SaveChanges();
            return Ok(loai);
        }
        [HttpDelete("id")]
        public IActionResult Delete(int id)
        {
            var loai = _context.Loais.SingleOrDefault(l => l.MaLoai == id);
            if (loai == null)
            {
                return NotFound();
            }
            _context.Remove(loai);
            _context.SaveChanges();
            return Ok(loai);
        }
    }
}
