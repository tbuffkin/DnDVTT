namespace DnDVTT.Models
{
    public class BattleMap
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public List<Token> Tokens { get; set; }
    }
}
