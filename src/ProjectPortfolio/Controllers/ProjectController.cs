using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio.Models;
using System.Collections.Generic;
using ProjectPortfolio.ViewModels;
using ProjectPortfolio.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace ProjectPortfolio.Controllers
{
    public class ProjectController : Controller
    {

        private readonly ProjectDbContext context;

        public ProjectController(ProjectDbContext dbContext)
        {
            this.context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<Project> projects = context.Projects.Include(c => c.Category).ToList();

            return View(projects);
        }

        public IActionResult Add()
        {
            AddProjectViewModel addProjectViewModel =
                new AddProjectViewModel(context.Categories.ToList());
            return View(addProjectViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddProjectViewModel addProjectViewModel)
        {
            if (ModelState.IsValid)
            {

               ProjectCategory newProjectCategory =
                    context.Categories.Single(c => c.ID == addProjectViewModel.CategoryID);

                // Add the new cheese to my existing cheeses
                Project newProject = new Project
                {
                    Name = addProjectViewModel.Name,
                    Description = addProjectViewModel.Description,
                    Category = newProjectCategory
                };
                context.Projects.Add(newProject);
                context.SaveChanges();

                return Redirect("/Project");
            }

            return View(addProjectViewModel);
        }

        public IActionResult Remove()
        {
            ViewBag.title = "Remove Projects";
            ViewBag.projects = context.Projects.ToList();
            return View();
        }

        [HttpPost]
        public IActionResult Remove(int[] projectIds)
        {

            foreach (int projectId in projectIds)
            {
               Project theProject = context.Projects.Single(c => c.ID == projectId);
                context.Projects.Remove(theProject);
            }

            context.SaveChanges();

            return Redirect("/");
        }

        public IActionResult Category(int id)
        {
            if (id == 0)
            {
                return Redirect("/Category");
            }

          ProjectCategory theCategory = context.Categories
                .Include(cat => cat.Projects)
                .Single(cat => cat.ID == id);

            // To query for the cheeses from the other 
            // side of the relationship:

            /*
             IList<Cheese> theCheeses = context.Cheeses
                .Include(c => c.Category)
                .Where(c => c.CategoryID == id)
                .ToList();
            */

            ViewBag.title = "Projects in category: " + theCategory.Name;

            return View("Index", theCategory.Projects);
        }
    }
}