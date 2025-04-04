namespace FlowerInventory.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<Flower> Flowers { get; set; } = new List<Flower>();
    }
}
