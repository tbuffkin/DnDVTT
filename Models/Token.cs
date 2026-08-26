namespace DnDVTT.Models
{
    public class Token
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string IconUrl { get; set; }
        public int X {  get; set; }
        public int Y { get; set; }
        public int BattleMapId { get; set; }
        public BattleMap BattleMap { get; set; }    

    }
}
