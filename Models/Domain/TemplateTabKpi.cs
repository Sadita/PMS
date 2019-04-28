using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.Domain
{
    public class TemplateTabKpi
    {

        
        public int TemplateTabId { get; set; }
        public TemplateTab TemplateTab { get; set; }

        public int KpiId { get; set; }
        public Kpi Kpi { get; set; }

    }
}
