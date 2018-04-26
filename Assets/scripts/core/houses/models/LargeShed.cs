public class LargeShed : HouseBase
{
    public static string NAME { get { return "Large Shed"; } }

    public override string Name { get { return NAME; } }
    public override double BaseCost { get { return 10.0; } }
    public override int BaseTotalCapacity { get { return 500; } }
}
