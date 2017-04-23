using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio.Models
{
    public class ProjectMenu
    {
        public int MenuID { get; set; }
        public Menu Menu { get; set; }

        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }


}