namespace DnDVTT.Models
{
    public class Character
    {
       
            public int Id { get; set; }
            public string Name { get; set; }
            public string Class { get; set; }
            public string Background { get; set; }
            public string Alignment { get; set; }
            public string Species { get; set; }
            public int Level { get; set; }

            public int Proficiency { get; set; }
            public int Walking { get; set; }
            public int Initiative {  get; set; }

           
            public int Strength { get; set; }
            public int Dexterity { get; set; }
            public int Constitution { get; set; }
            public int Intelligence { get; set; }
            public int Wisdom { get; set; }
            public int Charisma { get; set; }
            public int ArmorClass { get; set; }

            public int CurrentHP { get; set; }
            public int MaxHP { get; set; }
            public string Notes {  get; set; }

            public string Inventory { get; set; }

            public string Conditions { get; set; }

            public string Spellbook { get; set; }

            public List<InventoryItem> InventoryItems { get; set; }
            public List<Spell> Spells { get; set; }




       

    }

}

