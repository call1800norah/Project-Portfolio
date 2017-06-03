using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ProjectPortfolio.ViewModels
{
    public class RemoveCategoryViewModel
    {
        public int ID { get; set; }
        [Required]
        [Display(Name = "Category Name")]
        public string Name { get; set; }
    }
}
