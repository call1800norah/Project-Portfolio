using Microsoft.AspNetCore.Mvc;
using ProjectPortfolio.ViewModels;
using ProjectPortfolio.Models;
using ProjectPortfolio.Data;
using System.Linq;
using System.Collections.Generic;

namespace ProjectPortfolio.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ProjectDbContext context;

        public CategoryController(ProjectDbContext dbContext)
        {
            context = dbContext;
        }

        // GET: /<controller>/
        public IActionResult Index()
        {
            IList<ProjectCategory> categories = context.Categories.ToList();
            return View(categories);
        }

        public IActionResult Add()
        {
            AddCategoryViewModel addCategoryViewModel = new AddCategoryViewModel();
            return View(addCategoryViewModel);
        }

        [HttpPost]
        public IActionResult Add(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                ProjectCategory newCategory = new ProjectCategory
                {
                    Name = addCategoryViewModel.Name
                };

                context.Categories.Add(newCategory);
                context.SaveChanges();

                return Redirect("/Category");
            }

            return View(addCategoryViewModel);
        }
        
    }
}