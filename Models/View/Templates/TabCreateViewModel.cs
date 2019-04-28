using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.View.Templates
{
    public class TabCreateViewModel
    {
        public int Id { get; set; }
        public ICollection<KpiCreateViewModel> Kpis { get; set; }
    }
}
