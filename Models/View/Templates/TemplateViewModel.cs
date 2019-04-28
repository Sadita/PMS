using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.View.Templates
{
    public class TemplateViewModel
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<TabViewModel> Tabs { get; set; }

    }
}
