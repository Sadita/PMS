using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.Domain
{
    public class Kpi
    {
        public int Id { get; set; }

        public string Name { get; set; }

        //public string Status { get; set;  }

        [DataType(DataType.DateTime)]
        public DateTime CreationDate { get; set; }

        public ICollection<Level> Levels { get; set; }

        public ICollection<TemplateTabKpi> TemplateTabKpis { get; set; }

    }
}
