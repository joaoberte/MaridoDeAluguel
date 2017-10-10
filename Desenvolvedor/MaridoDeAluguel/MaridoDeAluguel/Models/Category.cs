using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaridoDeAluguel.Models
{
    public class Category
    {
        public Category() { }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual Category ParentCategory { get; set; }

        public ICollection<Category> SubCategories { get; set; }

        public ICollection<AdItem> AdItens { get; set; }
    }
}