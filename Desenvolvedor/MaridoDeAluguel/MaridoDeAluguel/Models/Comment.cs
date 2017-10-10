using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MaridoDeAluguel.Models
{
    public class Comment
    {
        public Comment() { }

        public int Id { get; set; }
        public string Text { get; set; }

        //public int ApplicationUserId { get; set; }
        //public virtual ApplicationUser ApplicationUser { get; set; }

        //public int AdItemId { get; set; }
        //public virtual AdItem AdItem { get; set; }

        //public int ImageId { get; set; }
        //public virtual Image Image { get; set; }

        //public int QuestionId { get; set; }
        //public virtual Comment Question { get; set; }
    }
}