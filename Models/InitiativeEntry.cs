namespace DnDVTT.Models
{
    public class InitiativeEntry
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Initiative { get; set; }
        public bool IsCurrentTurn { get; set; }
    }
}
