using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.Domain
{
    public class TemplateTab
    {

        public int Id { get; set; }

        public int TemplateId { get; set; }

        public Template Template { get; set; }

        public int TabId { get; set; }

        public Tab Tab { get; set; }

        public ICollection<TemplateTabKpi> TemplateTabKpis { get; set; }

    }
}
