namespace Rewrite;

public static class Ships
{
    public static List<Ship> ShipList()
    {
        List<Ship> list = new List<Ship>
        {
            new Ship {Id = 1, Name = "T-65 XWing Space Superiority Starfighter", Slug = "xwing"},
            new Ship {Id = 2, Name = "TIE/ln Space Superiority Starfighter", Slug = "tiefighter"},
            new Ship {Id = 3, Name = "TIE x1 Advanced Starfighter", Slug = "tieadvanced"},
            new Ship {Id = 4, Name = "BTL-A4 YWing assault starfighter/bomber", Slug = "ywing"}
        };

        return list;
    }
}

public class Ship
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Slug { get; set; }
}