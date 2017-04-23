using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPortfolio.Models;

namespace ProjectPortfolio.ViewModels
{
    public class ViewMenuViewModel
    {
        public IList<ProjectMenu> Items { get; set; }
        public Menu Menu { get; set; }
    }

}
