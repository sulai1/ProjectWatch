using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectWatch.Models
{
    public class Element
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid ID { get; set; }
        public string Type { get; set; }

        public Guid ProjectId { get; set; }
        public Project Project { get; set; }
    }
}
