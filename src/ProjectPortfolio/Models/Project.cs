using System.Collections.Generic;

namespace ProjectPortfolio.Models
{
    public class Project
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int CategoryID { get; set; }
        public ProjectCategory Category { get; set; }

        public List<ProjectMenu>ProjectMenus { get; set; } = new List<ProjectMenu>();
    }
}