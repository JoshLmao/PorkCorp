public class Bungalow : IHouse
{
    public static string NAME { get { return "Bungalow"; } }

    public string Name { get { return NAME; } }
    public int HouseIndex { get; set; }

    public double PigsPerSecond { get; set; }

    public double BaseCost { get { return 250.0; } }

    public int TotalCapacity { get { return 1000; } }
    public int CurrentCapacity { get; set; }
}
