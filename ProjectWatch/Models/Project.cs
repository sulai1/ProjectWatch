using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWatch.Models
{
    public class Project
    {
        public Guid ID { get; set; }
        public String Name { get; set; }
        public String Desc { get; set; }

        public List<Element> Elements { get; set; } = new List<Element>(); 
    }
}
