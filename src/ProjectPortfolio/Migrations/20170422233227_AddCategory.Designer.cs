using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using ProjectPortfolio.Data;

namespace ProjectPortfolio.Migrations
{
    [DbContext(typeof(ProjectDbContext))]
    [Migration("20170422233227_AddCategory")]
    partial class AddCategory
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProjectPortfolio.Models.Menu", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Menus");
                });

            modelBuilder.Entity("ProjectPortfolio.Models.Project", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CategoryID");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.HasIndex("CategoryID");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("ProjectPortfolio.Models.ProjectCategory", b =>
                {
                    b.Property<int>("ID")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("ID");

                    b.ToTable("Categories");
                });

            modelBuilder.Entity("ProjectPortfolio.Models.ProjectMenu", b =>
                {
                    b.Property<int>("ProjectID");

                    b.Property<int>("MenuID");

                    b.HasKey("ProjectID", "MenuID");

                    b.HasIndex("MenuID");

                    b.HasIndex("ProjectID");

                    b.ToTable("ProjectMenus");
                });

            modelBuilder.Entity("ProjectPortfolio.Models.Project", b =>
                {
                    b.HasOne("ProjectPortfolio.Models.ProjectCategory", "Category")
                        .WithMany("Projects")
                        .HasForeignKey("CategoryID")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("ProjectPortfolio.Models.ProjectMenu", b =>
                {
                    b.HasOne("ProjectPortfolio.Models.Menu", "Menu")
                        .WithMany("ProjectMenus")
                        .HasForeignKey("MenuID")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("ProjectPortfolio.Models.Project", "Project")
                        .WithMany("ProjectMenus")
                        .HasForeignKey("ProjectID")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}
