public class Mansion : HouseBase
{
    public static string NAME { get { return "Mansion"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return 1000.0; } }
    public override int BaseTotalCapacity { get { return 7500; } }
}
