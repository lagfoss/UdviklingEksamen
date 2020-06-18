using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UdviklingEksamen.Data;
using UdviklingEksamen.Models;

namespace UdviklingEksamen.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KategorisController : ControllerBase
    {
        private readonly ProduktContext _context;

        public KategorisController(ProduktContext context)
        {
            _context = context;
        }

        // GET: api/kategoris
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kategori>>> GetKategoris()
        {
            return await _context.Kategoris.ToListAsync();
        }

        // GET: api/kategoris/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Kategori>> GetKategori(int id)
        {
            var kategori = await _context.Kategoris.FindAsync(id);

            if (kategori == null)
            {
                return NotFound();
            }

            return kategori;
        }

        // PUT: api/kategoris/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKategori(int id, Kategori kategori)
        {
            if (id != kategori.Id)
            {
                return BadRequest();
            }

            _context.Entry(kategori).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KategoriExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/kategoris
        [HttpPost]
        public async Task<ActionResult<Kategori>> PostKategori(Kategori kategori)
        {
            _context.Kategoris.Add(kategori);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKategori", new { id = kategori.Id }, kategori);
        }

        // DELETE: api/Kategoris/{id}
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kategori>> DeleteKategori(int id)
        {
            var kategori = await _context.Kategoris.FindAsync(id);
            if (kategori == null)
            {
                return NotFound();
            }

            _context.Kategoris.Remove(kategori);
            await _context.SaveChangesAsync();

            return kategori;
        }

        private bool KategoriExists(int id)
        {
            return _context.Kategoris.Any(e => e.Id == id);
        }
    }
}
