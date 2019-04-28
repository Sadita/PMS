using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.View.Templates
{
    public class KpiViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime CreationDate { get; set; }

        public ICollection<LevelViewModel> Levels { get; set; }

    }
}
