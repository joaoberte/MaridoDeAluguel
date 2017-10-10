using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MaridoDeAluguel.Models
{
    public class State
    {
        public State() { }

        public int Id { get; set; }
        public string Name { get; set; }

        [StringLength(3)]
        public string UF { get; set; }

        public virtual Country Country { get; set; }
        
    }
}