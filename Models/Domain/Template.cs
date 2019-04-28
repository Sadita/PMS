using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PMS.Models.Domain
{
    public class Template
    {

        public int Id { get; set; }

        public string Name { get; set; }

        //[DataType(DataType.DateTime)]
        //public  DateTime YearCreated { get; set; }

        public ICollection<TemplateTab> TemplateTabs { get; set; }


    }
}
