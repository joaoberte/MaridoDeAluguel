using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MaridoDeAluguel.Models
{
    public class AdItem
    {

        public AdItem() { }

        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        [Required]
        public bool flagType { get; set; }

        public string Description { get; set; }

        public virtual City City { get; set; }

        [Required]
        public int CityId { get; set; }

        public virtual State State { get; set; }

        [Required]
        public int StateId { get; set; }

        public virtual ApplicationUser Owner { get; set; }

        [Required]
        public string OwnerId { get; set; }

        public virtual ApplicationUser Buyer { get; set; }
        public string BuyerId { get; set; }


        public virtual Category Category { get; set; }

        [Required]
        public int CategoryId { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime? PostedAt { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime ClosedAt { get; set; }

        public virtual ICollection<Images> Images { get; set; }
    }
}