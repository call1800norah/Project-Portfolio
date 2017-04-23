using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ProjectPortfolio.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace ProjectPortfolio.ViewModels
{
    public class AddMenuItemViewModel
    {

        public Menu Menu { get; set; }
        public List<SelectListItem> Projects { get; set; }

        public int MenuID { get; set; }
        public int ProjectID { get; set; }

        public AddMenuItemViewModel() { }

        public AddMenuItemViewModel(Menu menu, IEnumerable<Project> projects)
        {
           Projects = new List<SelectListItem>();

            foreach (var project in projects)
            {
                Projects.Add(new SelectListItem
                {
                    Value = project.ID.ToString(),
                    Text = project.Name

                });

            }
            Menu = menu;

        }


    }
}
