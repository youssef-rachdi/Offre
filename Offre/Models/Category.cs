using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Offre.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Catégorie")]
        public string CategoryName { get; set; }
        [Required]
        [Display(Name = "description")]
        public string CatregoryDescription { get; set; }

        public virtual ICollection<Job> Jobs { get; set; }
    }
}