using MaridoDeAluguel.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace MaridoDeAluguel.ViewModel
{
    public class AdItemFormViewModel
    {
        public AdItemFormViewModel()
        {
            ImageUpload = new List<HttpPostedFileBase>();

        }

        [StringLength(50, ErrorMessage = "O {0} deve ter no Máximo 50 caracteres.")]
        [Required(ErrorMessage = "Título é obrigatório")]
        [Display(Name = "Título*")]
        public string Title { get; set; }

        [Required]
        [Display(Name = "Residencial/Empresarial")]
        public bool flagType { get; set; }


        [Display(Name = "Descrição")]
        public string Description { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar a cidade")]
        [Display(Name = "Cidade*")]
        public int City { get; set; }

        public IEnumerable<City> Cities { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar o estado")]
        [Display(Name = "Estado*")]
        public int State { get; set; }

        public IEnumerable<State> States { get; set; }

        [Required(ErrorMessage = "É obrigatório selecionar a categoria")]
        [Display(Name = "Categoria*")]
        public byte Category { get; set; }

        public IEnumerable<Category> Categories { get; set; }
        //public City City { get; set; }

        [Display(Name = "Imagens")]
        public List<HttpPostedFileBase> ImageUpload { get; set; }

        public DateTime PostedAt { get; set; }
    }
}