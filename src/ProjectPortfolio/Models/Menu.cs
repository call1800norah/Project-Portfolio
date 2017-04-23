using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio.Models
{
    public class Menu
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public IList<ProjectMenu> ProjectMenus { get; set; } = new List<ProjectMenu>();
    }
}
