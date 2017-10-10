using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaridoDeAluguel.Models
{
    public class Country
    {
        public Country() { }

        public int Id { get; set; }
        public string Name { get; set; }

        public ICollection<State> States { get; set; }
    }
}