using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.Domain
{
    public class Tab
    {

        public int Id { get; set; }

        public string Title { get; set; }

        public ICollection<TemplateTab> TemplateTabs { get; set; }



    }
}
