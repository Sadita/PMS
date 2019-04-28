using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMS.Models.Domain;
using PMS.Models.View.Templates;

namespace PMS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TemplatesController : ControllerBase
    {
        private readonly PMSDBContext _context;

        public TemplatesController(PMSDBContext context)
        {
            _context = context;
        }

        // GET: api/Templates
        [HttpGet]
        public ActionResult<IEnumerable<TemplateViewModel>> GetTemplates()
        {
            var templates = _context.Templates.Include(t => t.TemplateTabs).ThenInclude(tt => tt.Tab)
                .Include(t => t.TemplateTabs).ThenInclude(tt => tt.TemplateTabKpis)
                .ThenInclude(ttk => ttk.Kpi).ThenInclude(k => k.Levels).ToList();

            var models = templates.Select(template => new TemplateViewModel
            {
                Id = template.Id,
                Name = template.Name,
                Tabs = template.TemplateTabs.Select(t => new TabViewModel
                {
                    Id = t.TabId,
                    Title = t.Tab.Title,
                    Kpis = t.TemplateTabKpis.Select(k => new KpiViewModel
                    {
                        Id = k.KpiId,
                        Name = k.Kpi.Name,
                        CreationDate = k.Kpi.CreationDate,
                        Levels = k.Kpi.Levels.Select(l => new LevelViewModel
                        {
                            Id = l.Id,
                            Name = l.Name,
                            Value = l.Value
                        }).ToList<LevelViewModel>()
                    }).ToList<KpiViewModel>()
                }).ToList<TabViewModel>()
            });

            if (templates == null)
            {
                return NotFound();
            }

            return new JsonResult(models);

        }

        // GET: api/Templates/5
        [HttpGet("{id}")]
        public async Task<ActionResult<TemplateViewModel>> GetTemplate(int id)
        {
            var template = await _context.Templates.Include(t => t.TemplateTabs).ThenInclude(tt => tt.Tab)
                .Include(t => t.TemplateTabs).ThenInclude(tt => tt.TemplateTabKpis)
                .ThenInclude(ttk => ttk.Kpi).ThenInclude(k => k.Levels)
                .FirstOrDefaultAsync(t => t.Id == id);

            var model = new TemplateViewModel
            {
                Id = template.Id,
                Name = template.Name,
                Tabs = template.TemplateTabs.Select(t => new TabViewModel
                {
                    Id = t.TabId,
                    Title = t.Tab.Title,
                    Kpis = t.TemplateTabKpis.Select(k => new KpiViewModel
                    {
                        Id = k.KpiId,
                        Name = k.Kpi.Name,
                        CreationDate = k.Kpi.CreationDate,
                        Levels = k.Kpi.Levels.Select(l => new LevelViewModel
                        {
                            Id = l.Id,
                            Name = l.Name,
                            Value = l.Value
                        }).ToList<LevelViewModel>()
                    }).ToList<KpiViewModel>()
                }).ToList<TabViewModel>()
            };

            if (template == null)
            {
                return NotFound();
            }

            return model;
        }

        // PUT: api/Templates/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutTemplate(int id, Template template)
        {
            if (id != template.Id)
            {
                return BadRequest();
            }

            _context.Entry(template).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TemplateExists(id))
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

        // POST: api/Templates
        [HttpPost]
        public async Task<ActionResult<Template>> PostTemplate(TemplateCreateViewModel model)
        {
            var template = new Template{
                Name = model.Name,
                TemplateTabs = model.Tabs.Select(t => new TemplateTab {
                    TabId = t.Id,
                    TemplateTabKpis = t.Kpis.Select(k => new TemplateTabKpi {
                        KpiId = k.Id
                    }).ToList<TemplateTabKpi>()
                }).ToList<TemplateTab>()
            };

            _context.Templates.Add(template);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetTemplate", new { id = template.Id }, template);
        }

        // DELETE: api/Templates/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Template>> DeleteTemplate(int id)
        {
            var template = await _context.Templates.FindAsync(id);
            if (template == null)
            {
                return NotFound();
            }

            _context.Templates.Remove(template);
            await _context.SaveChangesAsync();

            return template;
        }

        private bool TemplateExists(int id)
        {
            return _context.Templates.Any(e => e.Id == id);
        }
    }
}
