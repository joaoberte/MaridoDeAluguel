namespace MaridoDeAluguel.Models
{
    public class City
    {
        public City() { }

        public int Id { get; set; }
        public string Name { get; set; }

        public virtual State State { get; set; }


    }
}