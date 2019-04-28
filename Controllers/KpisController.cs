using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Models.Domain;

namespace PMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KpisController : ControllerBase
    {
        private readonly PMSDBContext _context;

        public KpisController(PMSDBContext context)
        {
            _context = context;
        }

        // GET: api/Kpis
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Kpi>>> GetKpis()
        {
            return await _context.Kpis.Include(k => k.Levels).ToListAsync();
        }

        // GET: api/Kpis/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Kpi>> GetKpi(int id)
        {
            var kpi = await _context.Kpis.Include(k => k.Levels).FirstOrDefaultAsync(k => k.Id == id);

            if (kpi == null)
            {
                return NotFound();
            }

            return kpi;
        }

        // PUT: api/Kpis/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKpi(int id, Kpi kpi)
        {
            if (id != kpi.Id)
            {
                return BadRequest();
            }

        //    _context.Entry(kpi).State = EntityState.Modified;

            try
            {
                var oldKpi = _context.Kpis
                                .Include(p => p.Levels)
                                .FirstOrDefault(p => p.Id == id);

                if (oldKpi != null)
                {
                    // Update parent
                    _context.Entry(oldKpi).CurrentValues.SetValues(kpi);

                    // Delete children
                    foreach (var level in oldKpi.Levels.ToList())
                    {
                        if (!kpi.Levels.Any(c => c.Id == level.Id))
                            _context.Levels.Remove(level);
                    }

                    // Update and Insert children
                    foreach (var level in kpi.Levels)
                    {
                        var oldLevel = oldKpi.Levels
                            .Where(c => c.Id == level.Id)
                            .FirstOrDefault();

                        if (oldLevel != null)
                            // Update child
                            _context.Entry(oldLevel).CurrentValues.SetValues(level);
                        else
                        {
                            // Insert child
                            //var newLevel = new Level
                            //{
                            //    Data = level.Data,
                            //    //...
                            //};
                            kpi.Levels.Add(level);
                        }
                    }



                    await _context.SaveChangesAsync();
                }
            }

            catch (DbUpdateConcurrencyException)
            {
                if (!KpiExists(id))
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

        // POST: api/Kpis
        [HttpPost]
        public async Task<ActionResult<Kpi>> PostKpi(Kpi kpi)
        {
            kpi.CreationDate = DateTime.Now;
            _context.Kpis.Add(kpi);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKpi", new { id = kpi.Id }, kpi);
        }

        // DELETE: api/Kpis/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Kpi>> DeleteKpi(int id)
        {
            var kpi = await _context.Kpis.FindAsync(id);
            if (kpi == null)
            {
                return NotFound();
            }

            _context.Kpis.Remove(kpi);
            await _context.SaveChangesAsync();

            return kpi;
        }

        private bool KpiExists(int id)
        {
            return _context.Kpis.Any(e => e.Id == id);
        }
    }
}
