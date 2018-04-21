public class Sty : IHouse
{
    public static string NAME { get { return "Sty"; } }

    public string Name { get { return NAME; } }
    public int HouseIndex { get; set; }

    public double PigsPerSecond { get; set; }

    public double BaseCost { get { return 1.0; } }

    public int TotalCapacity { get { return 250; } }
    public int CurrentCapacity { get; set; }
}
