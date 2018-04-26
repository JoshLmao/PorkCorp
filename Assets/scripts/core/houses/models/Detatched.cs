public class Detatched : HouseBase
{
    public static string NAME { get { return "Detatched"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return 500.0; } }
    public override int BaseTotalCapacity { get { return 2500; } }
}
