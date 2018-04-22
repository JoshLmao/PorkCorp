public class Detatched : IHouse
{
    public static string NAME { get { return "Detatched"; } }

    public string Name { get { return NAME; } }
    public int HouseIndex { get; set; }

    public double PigsPerSecond { get; set; }

    public double BaseCost { get { return 500.0; } }

    public int TotalCapacity { get { return 2500; } }
    public int CurrentCapacity { get; set; }
}
