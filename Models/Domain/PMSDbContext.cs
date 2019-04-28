using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.Domain
{
    public class PMSDBContext : DbContext
    {
        public PMSDBContext(DbContextOptions<PMSDBContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<TemplateTab>()
            //    .HasKey(tt => new { tt.TemplateId, tt.TabId });

            modelBuilder.Entity<TemplateTab>()
                .HasOne(tt => tt.Template)
                .WithMany(tmpl => tmpl.TemplateTabs)
                .HasForeignKey(tt => tt.TemplateId);
            modelBuilder.Entity<TemplateTab>()
                .HasOne(tt => tt.Tab)
                .WithMany(t => t.TemplateTabs)
                .HasForeignKey(tt => tt.TabId);

            modelBuilder.Entity<TemplateTabKpi>()
                .HasKey(ttk => new { ttk.TemplateTabId, ttk.KpiId });
            modelBuilder.Entity<TemplateTabKpi>()
                .HasOne(ttk => ttk.TemplateTab)
                .WithMany(tt => tt.TemplateTabKpis)
                .HasForeignKey(ttk => ttk.TemplateTabId);
            modelBuilder.Entity<TemplateTabKpi>()
                .HasOne(ttk => ttk.Kpi)
                .WithMany(k => k.TemplateTabKpis)
                .HasForeignKey(ttk => ttk.KpiId);

        }

        public DbSet<PMS.Models.Domain.Employee> Employees { get; set; }
        public DbSet<PMS.Models.Domain.Kpi> Kpis { get; set; }
        public DbSet<PMS.Models.Domain.Level> Levels { get; set; }
        public DbSet<PMS.Models.Domain.Template> Templates { get; set; }
        public DbSet<PMS.Models.Domain.Tab> Tabs { get; set; }
        public DbSet<PMS.Models.Domain.TemplateTab> TemplateTabs { get; set; }
        public DbSet<PMS.Models.Domain.TemplateTabKpi> TemplateTabKpis { get; set; }



    }
}
