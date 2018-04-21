public class LargeShed : IHouse
{
    public static string NAME { get { return "Large Shed"; } }

    public string Name { get { return NAME; } }
    public int HouseIndex { get; set; }

    public double PigsPerSecond { get; set; }

    public double BaseCost { get { return 10.0; } }

    public int TotalCapacity { get { return 1000; } }
    public int CurrentCapacity { get; set; }
}
