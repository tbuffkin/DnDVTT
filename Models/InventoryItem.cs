namespace DnDVTT.Models
{
    public class InventoryItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int Quantity { get; set; }
        public int CharacterID { get; set; }
        public Character Character { get; set; }
    }
}
