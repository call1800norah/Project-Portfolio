using ProjectPortfolio.Models;
using Microsoft.EntityFrameworkCore;

namespace ProjectPortfolio.Data
{
    public class ProjectDbContext : DbContext
    {
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectCategory> Categories { get; set; }
        public DbSet<Menu> Menus { get; set; }
        public DbSet<ProjectMenu> ProjectMenus { get; set; }

        public ProjectDbContext(DbContextOptions<ProjectDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBilder)
        {
            modelBilder.Entity<ProjectMenu>()
                .HasKey(c => new { c.ProjectID, c.MenuID });
        }

    }
}
