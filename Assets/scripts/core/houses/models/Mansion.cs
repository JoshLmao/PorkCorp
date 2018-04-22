public class Mansion : IHouse
{
    public static string NAME { get { return "Mansion"; } }

    public string Name { get { return NAME; } }
    public int HouseIndex { get; set; }

    public double PigsPerSecond { get; set; }

    public double BaseCost { get { return 1000.0; } }

    public int TotalCapacity { get { return 7500; } }
    public int CurrentCapacity { get; set; }
}
