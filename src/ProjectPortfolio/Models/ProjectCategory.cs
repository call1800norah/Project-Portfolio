using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio.Models
{
    public class ProjectCategory
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public IList<Project> Projects { get; set; }
    }
}