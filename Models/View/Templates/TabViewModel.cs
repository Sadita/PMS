using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.View.Templates
{
    public class TabViewModel
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<KpiViewModel> Kpis { get; set; }

    }
}
