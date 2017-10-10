using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MaridoDeAluguel.ViewModel
{
    public class CategoryViewModel
    {
        public CategoryViewModel() { }

        [Display(Name = "Nome")]
        public string Name { get; set; }

        public SelectList ParentCategories { get; set; }

        [Display(Name = "Categoria pai")]
        public int? SelectedCategorie { get; set; }
    }
}