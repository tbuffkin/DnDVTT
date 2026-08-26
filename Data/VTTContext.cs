using Microsoft.EntityFrameworkCore;
using DnDVTT.Models;

namespace DnDVTT.Data
{

    public class VTTContext : DbContext 
    {
        public VTTContext(DbContextOptions<VTTContext> options) : base(options) { }

        public DbSet<BattleMap> BattleMaps { get; set; }
        public DbSet<Token> Tokens { get; set; }
        public DbSet<Character> Characters { get; set; }

public DbSet<DnDVTT.Models.InventoryItem> InventoryItem { get; set; } = default!;

public DbSet<DnDVTT.Models.Spell> Spell { get; set; } = default!;
    }
}
