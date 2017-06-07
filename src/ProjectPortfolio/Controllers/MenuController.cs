using ProjectPortfolio.Data;
using ProjectPortfolio.Models;
using ProjectPortfolio.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectPortfolio.Controllers
{
    public class MenuController : Controller
    {
        private readonly ProjectDbContext context;

        public MenuController(ProjectDbContext dbContext)
        {
            context = dbContext;
        }
        public IActionResult Index()
        {
            List<Menu> menus = context.Menus.ToList();
            return View(menus);
        }
        public IActionResult Add()
        {
            AddMenuViewModel addMenuViewModel = new AddMenuViewModel();
            return View(addMenuViewModel);
        }
        [HttpPost]
        public IActionResult Add(AddMenuViewModel addMenuViewModel)
        {
            if (ModelState.IsValid)
            {
                Menu newMenu = new Menu
                {
                    Name = addMenuViewModel.Name
                };
                context.Menus.Add(newMenu);
                context.SaveChanges();

                return Redirect("/Menu");
            }
            return View(addMenuViewModel);
        }
        public IActionResult ViewMenu(int id)
        {
            List<ProjectMenu> items = context
                .ProjectMenus
                .Include(item => item.Project)
                .Where(cm => cm.MenuID == id)
                .ToList();

            Menu menu = context.Menus.Single(m => m.ID == id);

            ViewMenuViewModel viewModel = new ViewMenuViewModel
            {
                Menu = menu,
                Items = items
            };
            return View(viewModel);
        }
        public IActionResult AddItem(int id)
        {
            Menu menu = context.Menus.Single(m => m.ID == id);
            List<Project> projects = context.Projects.ToList();
            return View(new AddMenuItemViewModel(menu, projects));

        }
        [HttpPost]
        public IActionResult AddItem(AddMenuItemViewModel addMenuItemViewModel)
        {
            if (ModelState.IsValid)
            {
                var projectID = addMenuItemViewModel.ProjectID;
                var menuID = addMenuItemViewModel.MenuID;

                IList<ProjectMenu> existingItems = context.ProjectMenus
                    .Where(cm => cm.ProjectID == projectID)
                    .Where(cm => cm.MenuID == menuID).ToList();

                if (existingItems.Count == 0)
                {
                   ProjectMenu menuItem = new ProjectMenu
                    {
                        Project = context.Projects.Single(c => c.ID == projectID),
                        Menu = context.Menus.Single(m => m.ID == menuID)
                    };
                    context.ProjectMenus.Add(menuItem);
                    context.SaveChanges();
                }
                return RedirectToAction("ViewMenu", new { id = addMenuItemViewModel.MenuID });
            }
            return View(addMenuItemViewModel);
        }
        //public IActionResult RemoveItem(int id)
        //{
        //    Menu menu = context.Menus.Single(m => m.ID == id);
        //    List<Project> projects = context.Projects.ToList();
        //    return View(new RemoveMenuItemViewModel(menu, projects));

        //}
        //[HttpPost]
        //public IActionResult RemoveItem(RemoveMenuItemViewModel removeMenuItemViewModel)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var projectID = removeMenuItemViewModel.ProjectID;
        //        var menuID = removeMenuItemViewModel.MenuID;

        //        IList<ProjectMenu> existingItems = context.ProjectMenus
        //            .Where(cm => cm.ProjectID == projectID)
        //            .Where(cm => cm.MenuID == menuID).ToList();

        //        if (existingItems.Count == 0)
        //        {
        //            ProjectMenu menuItem = new ProjectMenu
        //            {
        //                Project = context.Projects.Single(c => c.ID == projectID),
        //                Menu = context.Menus.Single(m => m.ID == menuID)
        //            };
        //            context.ProjectMenus.Remove(menuItem);
        //            context.SaveChanges();
        //        }
        //        return RedirectToAction("ViewMenu", new { id = removeMenuItemViewModel.MenuID });
        //    }
        //    return View(removeMenuItemViewModel);
        //}
    }
}

